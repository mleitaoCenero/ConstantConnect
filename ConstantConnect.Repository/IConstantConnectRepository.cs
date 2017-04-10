using System;
using System.Collections.Generic;
using System.Linq;
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.Shared;

namespace ConstantConnect.Repository
{
    public interface IConstantConnectRepository
    {
        Device GetDevice(long id, Guid? crmRoomID);
        IQueryable<Device> GetDevices();
        IQueryable<Device> GetDevices(Guid? crmRoomID);
        IQueryable<Event> GetEvents();
        IQueryable<Event> GetEvents(Guid? crmRoomID);
        Event GetEvents(long id, Guid? crmRoomID);
        Organization GetOrganization(Guid id);
        IQueryable<Organization> GetOrganizations();
        IQueryable<RoomDetail> GetRoomDetail(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        RoomDetail GetRoomDetail(Guid id);
        IQueryable<RoomDetail> GetRoomDetails();
        IQueryable<RoomDetail> GetRoomDetailsWithDevices();
        IQueryable<RoomDetail> GetRoomDetailWithDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        RoomDetail GetRoomDetailWithDevices(Guid id);
        IQueryable<RoomSummary> GetRoomSummaries();
        IQueryable<RoomSummary> GetRoomSummaries(Guid? crmRoomID);
        RoomSummary GetRoomSummary(long id, Guid? crmRoomID);
    }
}