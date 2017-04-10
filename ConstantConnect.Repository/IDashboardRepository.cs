using System;
using System.Collections.Generic;
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.CRM;

namespace ConstantConnect.Repository
{
    public interface IDashboardRepository
    {
        List<Entities.ConstantConnect.Dashboard_ActiveRooms_Result> GetActiveRoomsTile(Guid contactId);
        List<Dashboard_ProactiveRooms_Result> GetProactiveRoomsTile(Guid contactId);
        List<Dashboard_RoomPerformance_Result> GetRoomPerformanceTile(Guid contactId);
        List<Dashboard_ServiceTickets_Result> GetServiceTicketsTile(Guid contactId);
        List<Dashboard_ServiceTicketTrends_Result> GetServiceTicketTrendsChart(
            Guid contactId, DateTime reportStart, DateTime reportEnd, string groupBy = null, 
            Nullable<System.Guid> roomId = null, string subject = null, Nullable<int> utcOffset = null
        );
    }
}