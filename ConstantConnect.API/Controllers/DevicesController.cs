using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Entities.Contexts;
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
    [RoutePrefix("api")]
    public class DevicesController : ApiController
    {
        IConstantConnectRepository _constantConnectRepository;
        DeviceFactory _deviceFactory = new DeviceFactory();

        const int MAXPAGESIZE = 10;
        public DevicesController()
        {
            _constantConnectRepository = new ConstantConnectRepository(new Repository.Entities.Contexts.ConstantConnectContext());
        }

        public DevicesController(IConstantConnectRepository repo)
        {
            _constantConnectRepository = repo;
        }

        [VersionedRoute("roomdetails/{new_clientRoomId}/devices", 1, Name = "DevicesForRoomDetails")]
        public IHttpActionResult Get(Guid new_clientRoomId, string fields = null, string sort = "DeviceName", 
            int page = 1, int pageSize = MAXPAGESIZE)
        {
            try
            {
                var listOfFields = new List<string>();
                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                var devices = _constantConnectRepository
                    .GetDevices(new_clientRoomId)
                    .ApplySort(sort);
                    //.Where(x => x.StateCode == statecode);

                if (devices == null)
                    return NotFound();

                if (pageSize > MAXPAGESIZE)
                    pageSize = MAXPAGESIZE;

                var totalCount = devices.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);

                var previousLink = page > 1 ? urlHelper.Link("DevicesForRoomDetails",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        clientRoomId = new_clientRoomId,
                        sort = sort,
                        fields = fields
                    }) : "";


                var nextLink = page < totalPages ? urlHelper.Link("DevicesForRoomDetails",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        new_clientRoomId = new_clientRoomId,
                        sort = sort,
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

                var result = devices
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize)
                    .ToList()
                    .Select(x => _deviceFactory.CreateDataShapedObject(x, listOfFields));
                return Ok(result);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        //Use Custom Request Header api-version:2 OR Accept:application/vnd.constantconnectapi.v2+json
        [VersionedRoute("roomdetails/{new_clientRoomId}/devices/{deviceId}", 1)]
        [VersionedRoute("devices/{deviceId}", 1)]
        public IHttpActionResult Get(long deviceId, Guid? new_clientRoomId = null, string fields = null)
        {
            try
            {
                var listOfFields = new List<string>();

                if (fields != null)
                    listOfFields = fields.ToLower().Split(',').ToList();

                Repository.Entities.ConstantConnect.Device device = null;

                if (new_clientRoomId == null)
                    device = _constantConnectRepository.GetDevice(deviceId, new_clientRoomId);
                else
                {
                    var devicesForRoomDetails = _constantConnectRepository.GetDevices(new_clientRoomId);

                    if (devicesForRoomDetails != null)
                        device = devicesForRoomDetails.FirstOrDefault(x => x.DeviceId == deviceId);
                }

                if (device != null)
                {
                    var returnValue = _deviceFactory.CreateDataShapedObject(device, listOfFields);
                    return Ok(returnValue);
                }
                else
                    return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
