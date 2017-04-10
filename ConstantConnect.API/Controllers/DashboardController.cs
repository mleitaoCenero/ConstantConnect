using ConstantConnect.API.Helpers;
using ConstantConnect.Repository;
using ConstantConnect.Repository.Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConstantConnect.API.Controllers
{
    [Authorize]
    public class DashboardController : ApiController
    {
        //IRoomRepository _roomRepository;
        IDashboardRepository _dashboardRepository;

        #region Constructors
        public DashboardController()
        {
            //var context = new CRMContext();
            //_roomRepository = new RoomRepository(context);
            _dashboardRepository = new DashboardRepository(new CRMContext(), new ConstantConnectContext());
        }

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        #endregion

        #region API's

        [Route("api/tile/{tile}")]
        [HttpGet]
        public IHttpActionResult Get(string tile)
        {
            try
            {
                string[] ownerId = TokenIdentityHelper.GetIdFromToken();

                //var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                //var listOfAutorizedRooms = _sharedRepository.GetActiveRooms(Guid.Parse(ownerId[1]));
                var userId = Guid.Parse(ownerId[1]);
                dynamic result;

                switch (tile)
                {
                    case "ActiveRooms":
                        result = _dashboardRepository.GetActiveRoomsTile(userId);
                        return Ok(result);
                    case "ProactiveRooms":
                        result = _dashboardRepository.GetProactiveRoomsTile(userId);
                        return Ok(result);
                    case "RoomPerformance":
                        result = _dashboardRepository.GetRoomPerformanceTile(userId);
                        return Ok(result);
                    case "ServiceTickets":
                        result = _dashboardRepository.GetServiceTicketsTile(userId);
                        return Ok(result);
                    default:
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        [Route("api/chart/{chart}")]
        [HttpGet]
        public IHttpActionResult Get(string chart, string startDate = null, string endDate = null, string roomId = null, string groupBy = null, string subject = null, Nullable<int> utcOffset = null)
        {
            try
            {
                string[] ownerId = TokenIdentityHelper.GetIdFromToken();

                var userId = Guid.Parse(ownerId[1]);

                // report start and end dates encompass the past 90 days by default, but can be set through URL variables
                var reportEnd = DateTime.Now;
                var reportStart = DateTime.Now.AddDays(-90);
                if (startDate != null && endDate != null)
                {
                    try
                    {
                        reportStart = DateTime.Parse(startDate);
                        reportEnd = DateTime.Parse(endDate);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                // optional roomid, default is null
                Nullable<System.Guid> reportRoomId = null;
                try
                {
                    reportRoomId = Guid.Parse(roomId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                dynamic result;

                switch (chart)
                {
                    case "ServiceTicketTrends":
                        result = _dashboardRepository.GetServiceTicketTrendsChart(
                            userId, reportStart, reportEnd, groupBy, reportRoomId, subject, utcOffset
                        );
                        return Ok(result);
                    default:
                        return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }




        #endregion
    }
}
