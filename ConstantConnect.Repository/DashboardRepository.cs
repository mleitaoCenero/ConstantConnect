using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.Contexts;
using ConstantConnect.Repository.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        CRMContext _crmContext;
        ConstantConnectContext _constantConnectContext;

        #region Constructors
        public DashboardRepository(CRMContext crmContext, ConstantConnectContext constantConnectContext)
        {
            _crmContext = crmContext;
            _crmContext.Configuration.LazyLoadingEnabled = false;
            _constantConnectContext = constantConnectContext;
            _constantConnectContext.Configuration.LazyLoadingEnabled = false;
        }

        public DashboardRepository(CRMContext crmContext)
        {
            _crmContext = crmContext;
            _crmContext.Configuration.LazyLoadingEnabled = false;
        }

        public DashboardRepository(ConstantConnectContext constantConnectContext)
        {
            _constantConnectContext = constantConnectContext;
            _constantConnectContext.Configuration.LazyLoadingEnabled = false;
        }

        #endregion


        #region IDashboard
        public List<Entities.ConstantConnect.Dashboard_ActiveRooms_Result> GetActiveRoomsTile(Guid contactId)
        {
            var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var result = _constantConnectContext.Database.SqlQuery<Entities.ConstantConnect.Dashboard_ActiveRooms_Result>("Dashboard_ActiveRooms @UserID", param).ToList();
            return result;
        }

        public List<Dashboard_ProactiveRooms_Result> GetProactiveRoomsTile(Guid contactId)
        {
            var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var result = _constantConnectContext.Database.SqlQuery<Dashboard_ProactiveRooms_Result>("Dashboard_ProactiveRooms @UserID", param).ToList();
            return result;
        }

        public List<Dashboard_RoomPerformance_Result> GetRoomPerformanceTile(Guid contactId)
        {
            var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var result = _crmContext.Database.SqlQuery<Dashboard_RoomPerformance_Result>("Dashboard_RoomPerformance @UserID", param).ToList();
            return result;
        }

        public List<Dashboard_ServiceTickets_Result> GetServiceTicketsTile(Guid contactId)
        {
            var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var result = _crmContext.Database.SqlQuery<Dashboard_ServiceTickets_Result>("Dashboard_ServiceTickets @UserID", param).ToList();
            return result;
        }

        public List<Dashboard_ServiceTicketTrends_Result> GetServiceTicketTrendsChart(Guid contactId, DateTime reportStart, DateTime reportEnd, string groupBy = null, Guid? roomId = default(Guid?), string subject = null, int? utcOffset = default(int?))
        {
            var param_userId = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var param_reportStart = new SqlParameter { ParameterName = "@ReportStart", Value = reportStart };
            var param_reportEnd = new SqlParameter { ParameterName = "@ReportEnd", Value = reportEnd };
            var param_groupBy = new SqlParameter { ParameterName = "@GroupBy", Value = groupBy != null ? groupBy : (Object)DBNull.Value };
            var param_roomId = new SqlParameter { ParameterName = "@RoomID", Value = roomId != null ? roomId : (Object)DBNull.Value };
            var param_subject = new SqlParameter { ParameterName = "@Subject", Value = subject != null ? subject : (Object)DBNull.Value };
            var param_utcOffset = new SqlParameter { ParameterName = "@UTCOffset", Value = utcOffset != null ? utcOffset : (Object)DBNull.Value };

            var result = _crmContext.Database.SqlQuery<Dashboard_ServiceTicketTrends_Result>(
                "Dashboard_ServiceTicketTrends @UserID, @ReportStart, @ReportEnd, @GroupBy, @RoomID, @Subject, @UTCOffset",
                param_userId, param_reportStart, param_reportEnd, param_groupBy, param_roomId, param_subject, param_utcOffset
            ).ToList();
            return result;
        }

        #endregion
    }
}
