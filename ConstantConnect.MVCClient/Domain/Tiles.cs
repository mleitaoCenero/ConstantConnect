using ConstantConnect.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConstantConnect.DTO.CRM;
using ConstantConnect.DTO.ConstantConnect;
using ConstantConnect.DTO.Shared;

namespace ConstantConnect.MVCClient.Domain
{
    public class Tiles
    {
        private IEnumerable<Room> clientRooms;
        private DashboardViewModel model;
        private IEnumerable<RoomDetail> roomDetails;

        public Tiles(DashboardViewModel model)
        {
            this.model = model;
        }

        public Tiles(IEnumerable<Room> clientRooms, IEnumerable<RoomDetail> roomDetails)
        {
            this.clientRooms = clientRooms;
            this.roomDetails = roomDetails;
        }

        public IEnumerable<DashboardTile> tileItems()
        {
            var tiles = new List<DashboardTile>();
            tiles.Add(new DashboardTile
            {
                Id = "active-rooms-tile",
                Title = "All Rooms",
                Description = @"Refers to the ""On/Off"" status of the main applications in the room. If the application is ""On"" the room is considered ""Active"". If the application is ""Off"" the room is considered ""Inactive"".",
                Icon = "glyphicons glyphicons-electrical-socket-us x3",
                Data = model.ActiveRoomsData.Count().ToString(),
                Position = 1,
                Color = "blue",
                LinkToTable = "#activerooms"
            });
            tiles.Add(new DashboardTile
            {
                Id = "proactive-rooms-tile",
                Title = "Proactive Rooms",
                Description = @"Provides a snapshot of all Proactive Rooms, their applications, and test history.",
                Icon = "fa fa-sitemap",
                Data = model.ProactiveRoomsData.Count().ToString(),
                Position = 2,
                Color = "green",
                LinkToTable = "#proactiverooms"
            });
            tiles.Add(new DashboardTile
            {
                Id = "room-performance-tile",
                Title = "Room Performance",
                Description = @"<p><small>Hours that a particular room had an open service ticket with a status of ""Down"" calculated against an eight (8) hour work day and the number of working days in the month.</small></p>" +
                               "<p><small><strong>Down:</strong> Core component(s) of the room(Audio, Video, Control, etc.) are not available for use. It is recommended that the room not be scheduled for use in this state.</small></p>" +
                               "<p><small><strong>Partial:</strong>Room is available for use, but some of the room functions may not be available.</small></p>" +
                               "<p><small><strong>Functional:</strong>Room is fully operational.</small></p>",
                Icon = "fa fa-line-chart",
                Data = model.RoomPerformanceData.Any() ? Math.Round((double)model.RoomPerformanceData.Average(t => t.UpTime)).ToString() : "0",
                Position = 3,
                Color = "yellow",
                LinkToTable = "#roomperformance"
            });
            tiles.Add(new DashboardTile
            {
                Id = "service-tickets-tile",
                Title = "Service Tickets",
                Description = @"Any room that currently has a ticket with a status of ""Active""",
                Icon = "fa fa-ticket",
                Data = model.ServiceTicketsData.Count(r => r.TicketState.Contains("Active")).ToString(),// clientRooms.Sum(r => r.Incidents.Count(i => i.StateCode == 0)).ToString(),
                Position = 3,
                Color = "red",
                LinkToTable = "#servicetickets"
            });

            return tiles;
        }
    }
}

