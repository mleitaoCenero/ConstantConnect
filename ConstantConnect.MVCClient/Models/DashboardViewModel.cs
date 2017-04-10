using ConstantConnect.DTO.ConstantConnect;
using ConstantConnect.DTO.CRM;
using ConstantConnect.DTO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConstantConnect.MVCClient.Models
{
    public class DashboardViewModel
    {
        //public IEnumerable<New_clientroom> ClientRooms { get; set; }
        public IEnumerable<Room> ClientRooms { get; set; }
        public IEnumerable<RoomDetail> RoomDetails { get; set; }
        public List<DashboardTile> Tiles { get; internal set; }
        //public List<DataTableTile> DataTables { get; internal set; }

        //public IEnumerable<DTO.ConstantConnect.Dashboard_ActiveRooms_Result> ActiveRoomsData { get; set; }
        public IEnumerable<DTO.Shared.Room> ActiveRoomsData { get; set; }
        public IEnumerable<DTO.ConstantConnect.Dashboard_ProactiveRooms_Result> ProactiveRoomsData { get; set; }
        public IEnumerable<DTO.CRM.Dashboard_RoomPerformance_Result> RoomPerformanceData { get; set; }
        public IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result> ServiceTicketsData { get; set; }

        public IEnumerable<DTO.CRM.SubjectBase> SubjectBaseData { get; set; }
    }
}