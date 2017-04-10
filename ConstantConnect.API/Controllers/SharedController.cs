using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Factories.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace ConstantConnect.API.Controllers
{
    public class SharedController : ApiController
    {
        ISharedRepository _sharedRepository;
        RoomFactory _roomFactory = new RoomFactory();
        const int MAXPAGESIZE = 10;

        #region Constructors
        public SharedController()
        {
            var crm = new Repository.Entities.Contexts.CRMContext();
            var cc = new Repository.Entities.Contexts.ConstantConnectContext();
            _sharedRepository = new SharedRepository(crm,cc);
        }

        public SharedController(ISharedRepository share)
        {
            _sharedRepository = share;
        }
        #endregion

        [VersionedRoute("api/room/{id}", 1)]
        public IHttpActionResult Get(Guid id, string fields = null)
        {
            try
            {
                bool includeIncidents = false;
                bool includeDevices = false;
                //bool includeNew_clientequipmemtipdata = false;
                var listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeIncidents = listOfFields.Any(f => f.Contains("incident"));
                    includeDevices = listOfFields.Any(f => f.Contains("device"));
                }

                Repository.Entities.Shared.Room room;

                if (includeIncidents && includeDevices)
                    room = _sharedRepository.GetRoomWithIncidentsAndDevices(id);
                else if (includeIncidents && !includeDevices)
                    room = _sharedRepository.GetRoomWithIncidents(id);
                else if (!includeIncidents && includeDevices)
                    room = _sharedRepository.GetRoomWithDevices(id);
                else
                    room = _sharedRepository.GetRoom(id);

                if (room != null)
                    return Ok(_roomFactory.CreateDataShapedObject(room, listOfFields));

                //return Ok(_new_clientroomFactory.CreateDataShapedObject(new_clientroom, listOfFields));
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

        [VersionedRoute("api/room", 1, Name = "roomList")]
        public IHttpActionResult Get(string fields = null, string sort = "Name",
            string city = null, string state = null,
            int page = 1, int pageSize = 5, bool nopage = true)
        {
            try
            {
                string[] ownerId = TokenIdentityHelper.GetIdFromToken();
                //Guid ownerId = Guid.Parse("3EB11A44-B95B-DC11-BE3C-000D9DDCDAF3");

                var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                //var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                //var listOfAutorizedRooms = _sharedRepository.GetRooms(Guid.Parse("3EB11A44-B95B-DC11-BE3C-000D9DDCDAF3"));
                //var crmList = _sharedRepository.GetCRMActiveRooms(Guid.Parse(ownerId[1]));
                //var ccList = _sharedRepository.GetCCActiveRooms(Guid.Parse(ownerId[1]));


                bool includeDevices = false;
                bool includeIncidents = false;
                var listOfFields = new List<string>();


                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeDevices = listOfFields.Any(i => i.Contains("device"));
                    includeIncidents = listOfFields.Any(i => i.Contains("incident"));
                }

                IQueryable<Repository.Entities.Shared.Room> rooms = null;

                if (includeDevices && includeIncidents)
                    rooms = _sharedRepository.GetRoomsWithIncidentsAndDevices(listOfAutorizedRooms);
                else if (includeDevices && !includeIncidents)
                    rooms = _sharedRepository.GetRoomsWithDevices(listOfAutorizedRooms);
                else if (!includeDevices && includeIncidents)
                    rooms = _sharedRepository.GetRoomsWithIncidents(listOfAutorizedRooms);
                else
                    rooms = _sharedRepository.GetRooms(listOfAutorizedRooms);

                rooms = rooms
                    .ApplySort(sort)
                    .Where(c => (city == null || c.City == city))
                    .Where(s => (state == null || s.State == state));
                //.Where(b => (building_campus == null || b.New_RoomOwnerIdName == building_campus));

                if (!nopage)
                {
                    if (pageSize > MAXPAGESIZE)
                        pageSize = MAXPAGESIZE;
                }
                else
                    pageSize = rooms.Count();

                var totalCount = rooms.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var previousLink = page > 1 ? urlHelper.Link("roomList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        city = city,
                        state = state,
                        //building_campus = building_campus,
                        fields = fields
                    }) : "";

                var nextLink = page < totalPages ? urlHelper.Link("roomList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        city = city,
                        state = state,
                        //building_campus = building_campus,
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

                return Ok(rooms
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _roomFactory.CreateDataShapedObject(x, listOfFields)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
