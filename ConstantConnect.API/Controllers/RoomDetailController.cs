using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Factories.ConstantConnect;
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
    //[Authorize]
    [EnableCors("*", "*", "*")]
    public class RoomDetailController : ApiController
    {
        IConstantConnectRepository _constantConnectRepository;
        ISharedRepository _sharedRepository;

        RoomDetailFactory _roomDetailFactory = new RoomDetailFactory();

        const int MAXPAGESIZE = 10;

        #region Constructors
        public RoomDetailController()
        {
            Repository.Entities.Contexts.ConstantConnectContext cc = new Repository.Entities.Contexts.ConstantConnectContext();
            _constantConnectRepository = new ConstantConnectRepository(
                cc);
            _sharedRepository = new SharedRepository(new Repository.Entities.Contexts.CRMContext(),cc);
        }

        public RoomDetailController(IConstantConnectRepository repo, ISharedRepository share)
        {
            _constantConnectRepository = repo;
            _sharedRepository = share;
        }
        #endregion

        [VersionedRoute("api/roomdetails", 1, Name = "roomdetailsList")]
        public IHttpActionResult Get(string fields = null, string sort = "roomName",
            string city = null, string state = null, string building_campus = null,
            int page = 1, int pageSize = 5, bool nopage = true)
        {
            try
            {
                string[] ownerId = TokenIdentityHelper.GetIdFromToken();

                //var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                //var crmList = _sharedRepository.GetCRMActiveRooms(Guid.Parse(ownerId[1]));
                //var ccList = _sharedRepository.GetCCActiveRooms(Guid.Parse(ownerId[1]));

                bool includeDevices = false;
                var listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeDevices = listOfFields.Any(i => i.Contains("device"));
                }

                IQueryable<Repository.Entities.ConstantConnect.RoomDetail> roomdetails = null;

                if (includeDevices)
                    roomdetails = _constantConnectRepository.GetRoomDetailWithDevices(listOfAutorizedRooms);
                else
                    roomdetails = _constantConnectRepository.GetRoomDetail(listOfAutorizedRooms);

                roomdetails = roomdetails
                    .ApplySort(sort);
                    //.Where(c => (city == null || c.new_City == city))
                    //.Where(s => (state == null || s.new_State == state))
                    //.Where(b => (building_campus == null || b.New_RoomOwnerIdName == building_campus));

                if(!nopage)
                {
                    if (pageSize > MAXPAGESIZE)
                        pageSize = MAXPAGESIZE;
                }
                else
                    pageSize = roomdetails.Count();

                var totalCount = roomdetails.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var previousLink = page > 1 ? urlHelper.Link("roomdetailsList",
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

                var nextLink = page < totalPages ? urlHelper.Link("roomdetailsList",
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

                return Ok(roomdetails
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _roomDetailFactory.CreateDataShapedObject(x, listOfFields)));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Get(Guid id, string fields = null)
        {
            try
            {
                bool includeDevices = false;
                var listOfFields = new List<string>();

                if (fields != null)
                {
                    listOfFields = fields.ToLower().Split(',').ToList();
                    includeDevices = listOfFields.Any(f => f.Contains("device"));
                }

                Repository.Entities.ConstantConnect.RoomDetail roomdetail;
                if (includeDevices)
                    roomdetail = _constantConnectRepository.GetRoomDetailWithDevices(id);
                else
                    roomdetail = _constantConnectRepository.GetRoomDetail(id);

                if (roomdetail != null)
                    return Ok(_roomDetailFactory.CreateDataShapedObject(roomdetail, listOfFields));
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
                throw;
            }
        }
    }
}
