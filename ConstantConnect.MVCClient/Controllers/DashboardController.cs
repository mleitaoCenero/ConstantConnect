using ConstantConnect.DTO.ConstantConnect;
using ConstantConnect.DTO.CRM;
using ConstantConnect.DTO.Shared;
using ConstantConnect.MVCClient.Domain;
using ConstantConnect.MVCClient.Helpers;
using ConstantConnect.MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public async Task<ActionResult> Index()
        {
            //var client = ConstantConnectHttpClient.GetClient();
            var model = new DashboardViewModel();

            using(var client = ConstantConnectHttpClient.GetClient())
            {
                var activeRoomData = await client.GetAsync("api/room");
                if (activeRoomData.IsSuccessStatusCode)
                {
                    var result = await activeRoomData.Content.ReadAsStringAsync();
                    //var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
                    var data = JsonConvert.DeserializeObject<List<DTO.Shared.Room>>(result);
                    model.ActiveRoomsData = data;
                }
            }

            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var proactiveRoomData = await client.GetAsync("api/tile/ProactiveRooms");
                if (proactiveRoomData.IsSuccessStatusCode)
                {
                    var result = await proactiveRoomData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.ConstantConnect.Dashboard_ProactiveRooms_Result>>(result);
                    model.ProactiveRoomsData = data;
                }
            }
            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var roomPerformanceData = await client.GetAsync("api/tile/RoomPerformance");
                if (roomPerformanceData.IsSuccessStatusCode)
                {
                    var result = await roomPerformanceData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_RoomPerformance_Result>>(result);
                    model.RoomPerformanceData = data;
                }
            }
            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var serviceTicketsData = await client.GetAsync("api/tile/ServiceTickets");
                if (serviceTicketsData.IsSuccessStatusCode)
                {
                    var result = await serviceTicketsData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result>>(result);
                    model.ServiceTicketsData = data;
                }
            }

            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var subjectBaseData = await client.GetAsync("api/SubjectBase");
                if (subjectBaseData.IsSuccessStatusCode)
                {
                    var result = await subjectBaseData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.SubjectBase>>(result);
                    model.SubjectBaseData = data;
                }
            }

            //var activeRoomData = await client.GetAsync("api/tile/ActiveRooms");
            var tiles = new Tiles(model);
            model.Tiles = tiles.tileItems().OrderBy(x => x.Position).ToList();

            return View(model);
            //return View();
        }
        #region Tiles
        //public async Task<ActionResult> TileActiveRooms()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var model = new DashboardTile<Dashboard_ActiveRooms_Result>()
        //    {
        //        Id = "active-rooms-tile",
        //        Title = "Active Rooms",
        //        Description = @"Refers to the ""On/Off"" status of the main applications in the room. If the application is ""On"" the room is considered ""Active"". If the application is ""Off"" the room is considered ""Inactive"".",
        //        Icon = "glyphicons glyphicons-electrical-socket-us x3",
        //        Position = 1,
        //        Color = "blue",
        //        LinkToTable = "#activerooms"
        //    };

        //    var activeRoomData = await client.GetAsync("api/tile/ActiveRooms").ConfigureAwait(false);

        //    if (activeRoomData.IsSuccessStatusCode)
        //    {
        //        var result = await activeRoomData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
        //        model.Data = data;
        //    }

        //    return PartialView(model);
        //}

        //public async Task<ActionResult> TileProactiveRooms()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var model = new DashboardTile<Dashboard_ActiveRooms_Result>()
        //    {
        //        Id = "proactive-rooms-tile",
        //        Title = "Proactive Rooms",
        //        Description = @"Provides a snapshot of all Proactive Rooms, their applications, and test history.",
        //        Icon = "fa fa-sitemap",
        //        Position = 2,
        //        Color = "green",
        //        LinkToTable = "#proactiverooms"
        //    };

        //    var activeRoomData = await client.GetAsync("api/tile/ProactiveRooms").ConfigureAwait(false);

        //    if (activeRoomData.IsSuccessStatusCode)
        //    {
        //        var result = await activeRoomData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
        //        model.Data = data;
        //    }

        //    return PartialView(model);
        //}

        //public async Task<ActionResult> TileRoomPerformance()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var model = new DashboardTile<Dashboard_RoomPerformance_Result>()
        //    {
        //        Id = "room-performance-tile",
        //        Title = "Room Performance",
        //        Description = @"<p><small>Hours that a particular room had an open service ticket with a status of ""Down"" calculated against an eight (8) hour work day and the number of working days in the month.</small></p>" +
        //                       "<p><small><strong>Down:</strong> Core component(s) of the room(Audio, Video, Control, etc.) are not available for use. It is recommended that the room not be scheduled for use in this state.</small></p>" +
        //                       "<p><small><strong>Partial:</strong>Room is available for use, but some of the room functions may not be available.</small></p>" +
        //                       "<p><small><strong>Functional:</strong>Room is fully operational.</small></p>",
        //        Icon = "fa fa-line-chart",
        //        Position = 3,
        //        Color = "yellow",
        //        LinkToTable = "#roomperformance"
        //    };

        //    var roomPerformanceData = await client.GetAsync("api/tile/RoomPerformance").ConfigureAwait(false);

        //    if (roomPerformanceData.IsSuccessStatusCode)
        //    {
        //        var result = await roomPerformanceData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_RoomPerformance_Result>>(result);
        //        model.Data = data;
        //    }

        //    return PartialView(model);
        //}

        //public async Task<ActionResult> TileServiceTickets()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var model = new DashboardTile<Dashboard_ServiceTickets_Result>()
        //    {
        //        Id = "service-tickets-tile",
        //        Title = "Service Tickets",
        //        Description = @"Any room that currently has a ticket with a status of ""Active""",
        //        Icon = "fa fa-ticket",
        //        Position = 3,
        //        Color = "red",
        //        LinkToTable = "#servicetickets"
        //    };

        //    var serviceTicketsData = await client.GetAsync("api/tile/ServiceTickets").ConfigureAwait(false);

        //    if (serviceTicketsData.IsSuccessStatusCode)
        //    {
        //        var result = await serviceTicketsData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result>>(result);
        //        model.Data = data;
        //    }

        //    return PartialView(model);
        //}

        #endregion

        #region Tables

        //public async Task<ActionResult> TableActiveRooms()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();

        //    List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result> resultData = null;

        //    var activeRoomData = await client.GetAsync("api/tile/ActiveRooms").ConfigureAwait(false);

        //    if (activeRoomData.IsSuccessStatusCode)
        //    {
        //        var result = await activeRoomData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
        //        resultData = data;
        //    }
        //    try
        //    {
        //        var model = new DataTableTile<Dashboard_ActiveRooms_Result>()
        //        {
        //            Id = "activerooms",
        //            Title = "Active Rooms",
        //            Description = "",
        //            Color = "blue",
        //            Position = 1,
        //            Width = "col-lg-6 col-md-6",
        //            AllowSearch = true,
        //            AllowFilter = true,
        //            FilterOptions = "Show Rooms In Use",
        //            Data = resultData,
        //        };
        //        return PartialView(model);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }



        //}

        //public async Task<ActionResult> TableProactiveRooms()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();

        //    List<DTO.ConstantConnect.Dashboard_ProactiveRooms_Result> resultData = null;

        //    var proactiveRoomData = await client.GetAsync("api/tile/ProactiveRooms").ConfigureAwait(false);

        //    if (proactiveRoomData.IsSuccessStatusCode)
        //    {
        //        var result = await proactiveRoomData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.ConstantConnect.Dashboard_ProactiveRooms_Result>>(result).ToList();
        //        resultData = data;
        //    }
        //    try
        //    {
        //        var model = new DataTableTile<Dashboard_ProactiveRooms_Result>()
        //        {
        //            Id = "proactiverooms",
        //            Title = "Proactive Rooms",
        //            Description = "",
        //            Color = "green",
        //            Position = 1,
        //            Width = "col-lg-6 col-md-6 col-offset-3",
        //            AllowSearch = true,
        //            AllowFilter = true,
        //            FilterOptions = "Show Rooms In Use",
        //            Data = resultData,
        //        };
        //        return PartialView(model);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }



        //}

        //public async Task<ActionResult> TableRoomPerformance()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();

        //    List<DTO.CRM.Dashboard_RoomPerformance_Result> resultData = null;

        //    var roomPerformanceData = await client.GetAsync("api/tile/RoomPerformance").ConfigureAwait(false);

        //    if (roomPerformanceData.IsSuccessStatusCode)
        //    {
        //        var result = await roomPerformanceData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_RoomPerformance_Result>>(result).ToList();
        //        resultData = data;
        //    }
        //    try
        //    {
        //        var model = new DataTableTile<Dashboard_RoomPerformance_Result>()
        //        {
        //            Id = "roomperformance",
        //            Title = "Room Performance",
        //            Description = "",
        //            Color = "yellow",
        //            Position = 1,
        //            Width = "col-lg-6 col-md-6 col-offset-3",
        //            AllowSearch = true,
        //            AllowFilter = true,
        //            FilterOptions = "Show Rooms In Use",
        //            Data = resultData,
        //        };
        //        return PartialView(model);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }



        //}

        //public async Task<ActionResult> TableServiceTickets()
        //{
        //    var client = ConstantConnectHttpClient.GetClient();

        //    List<DTO.CRM.Dashboard_ServiceTickets_Result> resultData = null;

        //    var roomPerformanceData = await client.GetAsync("api/tile/ServiceTickets").ConfigureAwait(false);

        //    if (roomPerformanceData.IsSuccessStatusCode)
        //    {
        //        var result = await roomPerformanceData.Content.ReadAsStringAsync().ConfigureAwait(false);
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result>>(result).ToList();
        //        resultData = data;
        //    }
        //    try
        //    {
        //        var model = new DataTableTile<Dashboard_ServiceTickets_Result>()
        //        {
        //            Id = "servicetickets",
        //            Title = "Service Tickets",
        //            Description = "",
        //            Color = "yellow",
        //            Position = 1,
        //            Width = "col-lg-6 col-md-6 col-offset-3",
        //            AllowSearch = true,
        //            AllowFilter = true,
        //            FilterOptions = "Show Rooms In Use",
        //            Data = resultData,
        //        };
        //        return PartialView(model);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        #endregion

        public async Task<ActionResult> ListView()
        {
            //var client = ConstantConnectHttpClient.GetClient();
            var model = new DashboardViewModel();

            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var activeRoomData = await client.GetAsync("api/room");
                if (activeRoomData.IsSuccessStatusCode)
                {
                    var result = await activeRoomData.Content.ReadAsStringAsync();
                    //var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.Shared.Room>>(result);
                    model.ActiveRoomsData = data;
                }
            }

            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var proactiveRoomData = await client.GetAsync("api/tile/ProactiveRooms");
                if (proactiveRoomData.IsSuccessStatusCode)
                {
                    var result = await proactiveRoomData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.ConstantConnect.Dashboard_ProactiveRooms_Result>>(result);
                    model.ProactiveRoomsData = data;
                }
            }
            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var roomPerformanceData = await client.GetAsync("api/tile/RoomPerformance");
                if (roomPerformanceData.IsSuccessStatusCode)
                {
                    var result = await roomPerformanceData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_RoomPerformance_Result>>(result);
                    model.RoomPerformanceData = data;
                }
            }
            using (var client = ConstantConnectHttpClient.GetClient())
            {
                var serviceTicketsData = await client.GetAsync("api/tile/ServiceTickets");
                if (serviceTicketsData.IsSuccessStatusCode)
                {
                    var result = await serviceTicketsData.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result>>(result);
                    model.ServiceTicketsData = data;
                }
            }

            return View(model);
            //return View();
        }

        public ActionResult ActiveRoomsTable()
        {
            return PartialView();
        }

        public ActionResult ProactiveRoomsTable()
        {
            return PartialView();
        }

        public async Task<ActionResult> ServiceTicketsTable()
        {
            var client = ConstantConnectHttpClient.GetClient();

            var model = new DashboardViewModel();

            var response = await client.GetAsync("api/tile/ServiceTickets");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                //var contentList = JsonConvert.DeserializeObject<IEnumerable<New_clientroom>>(content);
                var contentList = JsonConvert.DeserializeObject<IEnumerable<Dashboard_ServiceTickets_Result>>(content);
                model.ServiceTicketsData = contentList;
            }
            else
                return Content("An error occurred.");


            return View(model);
        }
        
    }
}