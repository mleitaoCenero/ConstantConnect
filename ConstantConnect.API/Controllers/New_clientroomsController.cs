using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Factories.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace ConstantConnect.API.Controllers
{
    [EnableCors("*","*", "*")]
    public class New_clientroomsController : ApiController
    {
        //IConstantConnectRepository _constantConnectRepository;
        ICRMRepository _crmRepository;
        ISharedRepository _sharedRepository;

        New_clientroomFactory _new_clientroomFactory = new New_clientroomFactory();

        const int MAXPAGESIZE = 10;
        public New_clientroomsController()
        {
            //_constantConnectRepository = new ConstantConnectRepository(
            //    new Repository.Entities.Contexts.ConstantConnectContext());
            Repository.Entities.Contexts.CRMContext crm = new Repository.Entities.Contexts.CRMContext();
            _crmRepository = new CRMRepository(
                crm);
            _sharedRepository = new SharedRepository(crm, 
                new Repository.Entities.Contexts.ConstantConnectContext());
        }

        public New_clientroomsController(ICRMRepository repo, ISharedRepository share)
        {
            _crmRepository = repo;
            _sharedRepository = share;
        }

        [VersionedRoute("api/new_clientrooms", 1, Name = "New_clientroomsList")]
        public IHttpActionResult Get(string fields = null, string sort="New_name",
            string city = null, string state=null, string building_campus=null,
            int page = 1, int pageSize = 5,bool nopage=true)
        {
            try
            {
                string[] ownerId = TokenIdentityHelper.GetIdFromToken();

                var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                //var crmList = _sharedRepository.GetCRMActiveRooms(Guid.Parse(ownerId[1]));
                //var ccList = _sharedRepository.GetCCActiveRooms(Guid.Parse(ownerId[1]));

                bool includeIncidents = false;
                bool includeNew_clientequipmemtipdata = false;
                var listOfFields = new List<string>();

                if(fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeIncidents = listOfFields.Any(i => i.Contains("incident"));
                    includeNew_clientequipmemtipdata = listOfFields.Any(i => i.Contains("New_clientequipmemtipdata"));
                }

                IQueryable<Repository.Entities.CRM.New_clientroom> new_clientrooms = null;
                if (includeIncidents && includeNew_clientequipmemtipdata)
                    new_clientrooms = _crmRepository.GetNew_clientroomsWithIncidentsAndNew_clientequipmentipdatas(listOfAutorizedRooms);
                else if(includeIncidents && !includeNew_clientequipmemtipdata)
                    new_clientrooms = _crmRepository.GetNew_clientroomsWithIncidents(listOfAutorizedRooms);
                else if (!includeIncidents && includeNew_clientequipmemtipdata)
                    new_clientrooms = _crmRepository.GetNew_clientroomsWithNew_clientequipmentipdatas(listOfAutorizedRooms);
                else
                    new_clientrooms = _crmRepository.GetNew_clientrooms(listOfAutorizedRooms);

                new_clientrooms = new_clientrooms
                    .ApplySort(sort)
                    .Where(c => (city == null || c.new_City == city))
                    .Where(s=> (state==null || s.new_State == state))
                    .Where(b=> (building_campus==null || b.New_RoomOwnerIdName == building_campus));

                if (!nopage)
                {
                    if (pageSize > MAXPAGESIZE)
                        pageSize = MAXPAGESIZE;
                }
                else
                    pageSize = new_clientrooms.Count();

                var totalCount = new_clientrooms.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var previousLink = page > 1 ? urlHelper.Link("New_clientRoomsList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        city = city,
                        state = state,
                        building_campus = building_campus,
                        fields = fields
                    }) : "";

                var nextLink = page < totalPages ? urlHelper.Link("New_clientroomsList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        city = city,
                        state = state,
                        building_campus = building_campus,
                        fields = fields
                    }) : "";

                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,
                    previousPageLink = previousLink,
                    nextPageLink = nextLink
                };

                HttpContext.Current.Response.Headers.Add("X-Pagination", 
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));

                return Ok(new_clientrooms
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _new_clientroomFactory.CreateDataShapedObject(x, listOfFields)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [VersionedRoute("api/new_clientrooms/{id}",1)]
        public IHttpActionResult Get(Guid id, string fields= null)
        {
            try
            {
                bool includeIncidents = false;
                bool includeNew_clientequipmemtipdata = false;
                var listOfFields = new List<string>();

                if(fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeIncidents = listOfFields.Any(f => f.Contains("incident"));
                    includeNew_clientequipmemtipdata = listOfFields.Any(f => f.Contains("new_clientequipmemtipdata"));
                }

                Repository.Entities.CRM.New_clientroom new_clientroom;
                if (includeIncidents && includeNew_clientequipmemtipdata)
                    new_clientroom = _crmRepository.GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatas(id);
                else if (!includeIncidents && includeNew_clientequipmemtipdata)
                    new_clientroom = _crmRepository.GetNew_clientroomWithNew_clientequipmentipdatas(id);
                else if (includeIncidents && !includeNew_clientequipmemtipdata)
                    new_clientroom = _crmRepository.GetNew_clientroomWithIncidents(id);
                else
                    new_clientroom = _crmRepository.GetNew_clientroom(id);

                if (new_clientroom != null)
                    return Ok(_new_clientroomFactory.CreateDataShapedObject(new_clientroom, listOfFields));
                else
                    return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
                throw;
            }
        }

        [VersionedRoute("api/clientroom/{id}", 1)]
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                //var room = _crmRepository.GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatas(id);
                var room = _crmRepository.GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatasAndNew_clientequipment(id);

                if (room != null)
                    return Ok(room);

                else
                    return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return InternalServerError();
                throw;
            }
        }


    }
}
