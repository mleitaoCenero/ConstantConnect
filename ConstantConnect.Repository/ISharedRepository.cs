using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Entities.Shared;
using System.Linq;

namespace ConstantConnect.Repository
{
    public interface ISharedRepository
    {
        IEnumerable<ActiveRooms> GetActiveRooms(Guid userId);
        List<Entities.ConstantConnect.Dashboard_ActiveRooms_Result> GetCCActiveRooms(Guid contactId);
        List<Entities.CRM.Dashboard_ActiveRooms_Result> GetCRMActiveRooms(Guid contactId);
        Task<List<ActiveRooms>> LoadCCDataAsync(Guid userId);
        Task<List<ActiveRooms>> LoadCRMDataAsync(Guid userId);

        Room GetRoom(Guid id);
        Room GetRoomWithIncidents(Guid id);
        Room GetRoomWithDevices(Guid id);
        Room GetRoomWithIncidentsAndDevices(Guid id);
        
        IQueryable<Room> GetRooms(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<Room> GetRoomsWithIncidentsAndDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<Room> GetRoomsWithIncidents(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<Room> GetRoomsWithDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms);
    }
}