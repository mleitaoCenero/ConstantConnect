using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstantConnect.Repository.Entities.Contexts;
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.Shared;

namespace ConstantConnect.Repository
{
    public class ConstantConnectRepository : IConstantConnectRepository
    {
        private ConstantConnectContext _constantConnectContext;

        #region Constructors
        public ConstantConnectRepository(ConstantConnectContext constantConnectContext)
        {
            this._constantConnectContext = constantConnectContext;
            _constantConnectContext.Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region Devices
        public Device GetDevice(long id, Guid? crmRoomID)
        {
            return _constantConnectContext.Devices.FirstOrDefault(e => e.DeviceId == id && (crmRoomID == null || e.RoomId == crmRoomID));
        }

        public IQueryable<Device> GetDevices(Guid? crmRoomID)
        {
            var correctEntity = _constantConnectContext.RoomDetails.FirstOrDefault(x => x.CrmRoomId == crmRoomID);
            if (correctEntity != null)
                return _constantConnectContext.Devices.Where(x => x.RoomId == crmRoomID);
            else
                return null;
        }

        public IQueryable<Device> GetDevices()
        {
            return _constantConnectContext.Devices;
        }

        #endregion

        #region Events

        public Event GetEvents(long id, Guid? crmRoomID)
        {
            return _constantConnectContext.Events.FirstOrDefault(e => e.EventId == id && (crmRoomID == null || e.RoomId == crmRoomID));
        }

        public IQueryable<Event> GetEvents(Guid? crmRoomID)
        {
            var correctEntity = _constantConnectContext.RoomDetails.FirstOrDefault(x => x.CrmRoomId == crmRoomID);
            if (correctEntity != null)
                return _constantConnectContext.Events.Where(x => x.RoomId == crmRoomID);
            else
                return null;
        }

        public IQueryable<Event> GetEvents()
        {
            return _constantConnectContext.Events;
        }

        #endregion

        #region EventGroups
        //Nothing here yet
        #endregion

        #region Organization
        public Organization GetOrganization(Guid id)
        {
            return _constantConnectContext.Organizations.FirstOrDefault(e => e.OrganizationId == id);
        }

        public IQueryable<Organization> GetOrganizations()
        {
            return _constantConnectContext.Organizations;
        }
        #endregion

        #region RoomDetail

        public RoomDetail GetRoomDetail(Guid id)
        {
            return _constantConnectContext.RoomDetails.FirstOrDefault(e => e.CrmRoomId == id);
        }

        public RoomDetail GetRoomDetailWithDevices(Guid id)
        {
            return _constantConnectContext.RoomDetails.Include("Devices").FirstOrDefault(x => x.CrmRoomId == id);
        }

        public IQueryable<RoomDetail> GetRoomDetails()
        {
            return _constantConnectContext.RoomDetails;
        }

        public IQueryable<RoomDetail> GetRoomDetailsWithDevices()
        {
            return _constantConnectContext.RoomDetails.Include("Devices");
        }

        public IQueryable<RoomDetail> GetRoomDetailWithDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            return _constantConnectContext.RoomDetails.Include("Devices").Where(r => list.Contains(r.CrmRoomId));
        }

        public IQueryable<RoomDetail> GetRoomDetail(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            var result = _constantConnectContext.RoomDetails.Where(r => list.Contains(r.CrmRoomId));
            return result;
        }

        #endregion

        #region RoomSummary

        public RoomSummary GetRoomSummary (long id, Guid? crmRoomID)
        {
            return _constantConnectContext.RoomSummaries.FirstOrDefault(e => e.LineId == id && (crmRoomID == null || e.RoomId == crmRoomID));
        }

        public IQueryable<RoomSummary> GetRoomSummaries(Guid? crmRoomID)
        {
            var correctEntity = _constantConnectContext.RoomSummaries.FirstOrDefault(x => x.RoomId == crmRoomID);
            if (correctEntity != null)
                return _constantConnectContext.RoomSummaries.Where(x => x.RoomId == crmRoomID);
            else
                return null;
        }

        public IQueryable<RoomSummary> GetRoomSummaries()
        {
            return _constantConnectContext.RoomSummaries;
        }

        #endregion
    }
}
