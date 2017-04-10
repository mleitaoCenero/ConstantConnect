using ConstantConnect.DTO.CRM;
using ConstantConnect.MVCClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Domain
{
    public class DataTables
    {
        private IEnumerable<New_clientroom> clientRooms;

        public DataTables(IEnumerable<New_clientroom> clientRooms)
        {
            this.clientRooms = clientRooms;
        }

        //public IEnumerable<DataTableTile> DataTableItems()
        //{
        //    var tiles = new List<DataTableTile>();

        //    tiles.Add(
        //        new DataTableTile
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
        //            Columns =
        //            {
        //                new TableColumn
        //                {
        //                    Title="Name",
        //                    Position=1,
        //                    RowSpan=2,
        //                    DisplayStyle="vertical-center"
        //                },
        //                new TableColumn
        //                {
        //                    Title="Application",
        //                    Position=2,
        //                    RowSpan=1,
        //                    ColSpan=5,
        //                    DisplayStyle="text-center"
        //                },
        //                new TableColumn
        //                {
        //                    Title="In Use",
        //                    Position=3,
        //                    RowSpan=2,
        //                    DisplayStyle="vertical-center text-center",
        //                    AllowSort="no-sort"
        //                },
        //                new TableColumn
        //                {
        //                    Title="CTRL",
        //                    Position = 4,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="VTC",
        //                    Position = 5,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="PRES",
        //                    Position = 6,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="ATC",
        //                    Position = 7,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="RC",
        //                    Position = 8,
        //                    DisplayStyle="small text-center min"
        //                }
        //            },
        //            Data = clientRooms,
        //            Discriptors =
        //            {
        //                new TableDiscriptor
        //                {
        //                    Position=1,
        //                    TextColor="blue",
        //                    Data="",
        //                    DescriptionHeader="Control",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=2,
        //                    TextColor="green",
        //                    Data="",
        //                    DescriptionHeader="Video Conference",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=3,
        //                    TextColor="yellow",
        //                    Data="",
        //                    DescriptionHeader="Presentation",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=4,
        //                    TextColor="red",
        //                    Data="",
        //                    DescriptionHeader="Audio Conference",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=5,
        //                    TextColor="light-blue",
        //                    Data="",
        //                    DescriptionHeader="RoomCheck",
        //                    DescriptionText="Total Rooms"
        //                }
        //            }
        //        });
        //    tiles.Add(
        //        new DataTableTile
        //        {
        //            Id = "proactiverooms",
        //            Title = "Proactive Rooms",
        //            Description = "",
        //            Color = "green",
        //            Position = 2,
        //            Width = "col-lg-6 col-md-6 col-lg-offset-3",
        //            AllowSearch = true,
        //            AllowFilter = false,
        //            Columns =
        //            {
        //                new TableColumn
        //                {
        //                    Title="Name",
        //                    Position=1,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="Online",
        //                    Position=2,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="CTRL",
        //                    Position=3,
        //                    DisplayStyle="small text-center min",
        //                },
        //                new TableColumn
        //                {
        //                    Title="VTC",
        //                    Position = 4,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="PRES",
        //                    Position = 5,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="ATC",
        //                    Position = 6,
        //                    DisplayStyle="small text-center min"
        //                },
        //                new TableColumn
        //                {
        //                    Title="Test History",
        //                    Position = 7,
        //                    DisplayStyle="small text-center min"
        //                }
        //            },
        //            Data = clientRooms,
        //            Discriptors =
        //            {
        //                new TableDiscriptor
        //                {
        //                    Position=1,
        //                    TextColor="blue",
        //                    Data="",
        //                    DescriptionHeader="Total",
        //                    DescriptionText="Proactive Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=2,
        //                    TextColor="green",
        //                    Data="",
        //                    DescriptionHeader="Online",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=3,
        //                    TextColor="yellow",
        //                    Data="",
        //                    DescriptionHeader="Video Conference",
        //                    DescriptionText="Total INUSE"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=4,
        //                    TextColor="red",
        //                    Data="",
        //                    DescriptionHeader="Audio Conference",
        //                    DescriptionText="Total Rooms"
        //                },
        //                new TableDiscriptor
        //                {
        //                    Position=5,
        //                    TextColor="light-blue",
        //                    Data="",
        //                    DescriptionHeader="Last Test",
        //                    DescriptionText="Date"
        //                }
        //            }
        //        });
        //    tiles.Add(
        //        new DataTableTile
        //        {
        //            Id = "roomperformance",
        //            Title = "Room Performance",
        //            Description = "",
        //            Color = "yellow",
        //            Position = 3,
        //            Width = "col-lg-6 col-md-6",
        //            AllowSearch = true,
        //            AllowFilter = false,
        //            Columns =
        //            {
        //                new TableColumn
        //                {
        //                    Title="Name",
        //                    Position=1,
        //                    DisplayStyle=""
        //                },
        //                new TableColumn
        //                {
        //                    Title="Percentage of Uptime",
        //                    Position=2,
        //                    DisplayStyle="text-right"
        //                },
        //                new TableColumn
        //                {
        //                    Title="Touchpanel Survey Scores",
        //                    Position=3,
        //                    RowSpan=2,
        //                    DisplayStyle="text-right",
        //                    AllowSort="no-sort"
        //                }
        //            },
        //            Data = clientRooms,
        //        });
        //    tiles.Add(
        //        new DataTableTile
        //        {
        //            Id = "servicetickets",
        //            Title = "Service Tickets",
        //            Description = "",
        //            Color = "red",
        //            Position = 4,
        //            Width = "col-lg-9 col-md-6 col-lg-offset-3",
        //            AllowSearch = true,
        //            AllowFilter = true,
        //            FilterOptions = "Show Closed Tickets",
        //            Columns =
        //            {
        //                new TableColumn
        //                {
        //                    Title="Name",
        //                    Position=1
        //                },
        //                new TableColumn
        //                {
        //                    Title="Ticket #",
        //                    Position=2
        //                },
        //                new TableColumn
        //                {
        //                    Title="Date Opened",
        //                    Position=3
        //                },
        //                new TableColumn
        //                {
        //                    Title="Subject",
        //                    Position=4
        //                },
        //                new TableColumn
        //                {
        //                    Title="Pre-Service",
        //                    Position=4
        //                },
        //                new TableColumn
        //                {
        //                    Title="Open/Closed",
        //                    Position=5
        //                },
        //                new TableColumn
        //                {
        //                    Title="Status",
        //                    Position=6
        //                }
        //            },
        //            Data = clientRooms,
        //        });

        //    return tiles;
        //}
    }
}