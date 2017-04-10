using ConstantConnect.Repository.Entities.Contexts;
using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Entities.Shared;
using ConstantConnect.Repository.Factories.Shared;
using ConstantConnect.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository
{
    public class SharedRepository : ISharedRepository
    {
        CRMContext _CRMContext;
        ConstantConnectContext _ConstantConnectContext;
        RoomFactory _roomFactory;

        public SharedRepository(CRMContext crmContext, ConstantConnectContext constantConnectContext)
        {
            _roomFactory = new RoomFactory();
            _CRMContext = crmContext;
            _ConstantConnectContext = constantConnectContext;
            _CRMContext.Configuration.LazyLoadingEnabled = false;
            _ConstantConnectContext.Configuration.LazyLoadingEnabled = false;
        }

        public List<Entities.ConstantConnect.Dashboard_ActiveRooms_Result> GetCCActiveRooms(Guid contactId)
        {
            var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
            var result = _ConstantConnectContext.Database.SqlQuery<Entities.ConstantConnect.Dashboard_ActiveRooms_Result>("Dashboard_ActiveRooms @UserID", param).ToList();
            return result;
        }

        public List<Entities.CRM.Dashboard_ActiveRooms_Result> GetCRMActiveRooms(Guid contactId)
        {
            try
            {
                var param = new SqlParameter { ParameterName = "@UserID", Value = contactId };
                var result = _CRMContext.Database.SqlQuery<Entities.CRM.Dashboard_ActiveRooms_Result>("Dashboard_ActiveRooms @UserID", param).ToList();
                
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public async Task<List<Entities.Shared.ActiveRooms>> LoadCRMDataAsync(Guid userId)
        {
            var crm = GetCRMActiveRooms(userId);
            List<Entities.Shared.ActiveRooms> result = new List<Entities.Shared.ActiveRooms>();
            
            foreach (var item in crm)
            {
                result.Add(
                    new Entities.Shared.ActiveRooms()
                    {
                        OrganizationID = item.OrganizationID,
                        OrganizationName = item.OrganizationName,
                        City = item.City,
                        State = item.State,
                        Country = item.Country,
                        RoomID = item.RoomID,
                        RoomName = item.RoomName
                    }
                );
            }
            return result;
            
        }

        public async Task<List<Entities.Shared.ActiveRooms>> LoadCCDataAsync(Guid userId)
        {
            var crm = GetCCActiveRooms(userId);
            List<Entities.Shared.ActiveRooms> result = new List<Entities.Shared.ActiveRooms>();
            foreach (var item in crm)
            {
                result.Add(
                    new Entities.Shared.ActiveRooms()
                    {
                        OrganizationID = item.OrganizationID,
                        OrganizationName = item.OrganizationName,
                        City = item.City,
                        State = item.State,
                        Country = item.Country,
                        RoomID = item.RoomID,
                        RoomName = item.RoomName
                    }
                );
            }
            return result;

        }

        public IEnumerable<Entities.Shared.ActiveRooms> GetActiveRooms(Guid userId)
        {
            var crm = LoadCRMDataAsync(userId).Result;
            var cc = LoadCCDataAsync(userId).Result;
            var uni = crm.Union(cc);

            return uni;
        }

        

        #region ROOM

        public Room GetRoom(Guid id)
        {
            var crm = _CRMContext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
            var cc = _ConstantConnectContext.RoomDetails.FirstOrDefault(x => x.CrmRoomId == id);
            var summary = _ConstantConnectContext.RoomSummaries.FirstOrDefault(x => x.RoomId == id);

            if(summary == null)
                return _roomFactory.BuildRoomEntity(crm, cc);
            
            return _roomFactory.BuildRoomEntity(crm, cc, summary);
        }

        public Room GetRoomWithIncidents(Guid id)
        {
            var crm = _CRMContext.New_clientroom.Include("Incident").FirstOrDefault(x => x.New_clientroomId == id);
            var cc = _ConstantConnectContext.RoomDetails.FirstOrDefault(x => x.CrmRoomId == id);
            var summary = _ConstantConnectContext.RoomSummaries.FirstOrDefault(x => x.RoomId == id);

            if (crm == null)
                return null;
            if (cc == null)
                cc = new Entities.ConstantConnect.RoomDetail();
            if (summary == null)
                summary = new Entities.ConstantConnect.RoomSummary();

            var room = _roomFactory.BuildRoomEntity(crm, cc, summary);
            return room;
        }

    //    public Room GetRoomWithInventory(Guid id)
    //    {
    //        try
    //        {
    //            var room = _CRMContext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
    //            if (room != null)
    //            {
    //                var clientEquipment = _CRMContext.New_clientequipment.Where(x => x.New_ClientRoomEquipmentId == id).ToList();
    //                var devices = _ConstantConnectContext.Devices.Where(x => x.RoomId == id).ToList();
    //                var InventoryItem = new InventoryItem();

    //                var result = from ce in clientEquipment
    //                             join d in devices on ce.New_clientequipmentId equals d.RoomId
    //                             select new InventoryItem
    //                             {
    //                                Id = ce.New_EquipmentId,
    //                                ClientRoomId = room.New_clientroomId,
    //                                ClientRoomName = room.New_name,

    //                                InventoryItemLoactionId = ce.New_ClientRoomEquipmentId,
    //                                InventoryItemLoactionName = ce.New_ClientRoomEquipmentIdName,

    //                                InventoryItemServiceLoactionName = ce.New_ServiceLocation,

    //                                ManufactuerId = ce.New_ManufacturerId,
    //                                ManufacturerName = ce.New_ManufacturerIdName,

    //                                EquipmentTypeName = ce.New_EquipmentType,

    //                                EquipmentFunctionId = ce.New_EquipmentFunctionId,
    //                                EquipmentFunctionName =ce.New_EquipmentFunctionIdName,

    //                                EquipmentStatusId = ce.New_EquipmentStatusId,
    //                                EquipmentStatusName = ce.New_EquipmentStatusIdName,

    //                                Name = ce.New_name,
    //                                Model = ce.New_Model,
    //                                ModelNumber = ce.New_ModelNumber,
    //                                SerialNumber = 
    //                                PartNumber =
    //                                PartDescription =
    //                                LocationInRoom =
    //                                AssetId =
    //                                Barcode =
    //                                BenAssetTag =
    //                                BenAssetNumber =
    //                                Frimware =
    //                                Loanable =
    //                                LoanContactName =
    //                                LoanContactInformation =
    //                                PoNumber =
    //                                RmaNumber =
    //                                WcitTag =
    //                                Notes =

    //}
                    

    //                return new Room();
    //            }

    //            else
    //                return null;

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            throw;
    //        }
    //    }

        public Room GetRoomWithDevices(Guid id)
        {
            try
            {
                var crm = _CRMContext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);

                var cc = _ConstantConnectContext.RoomDetails.Include("Devices").FirstOrDefault(x => x.CrmRoomId == id);
                //var dev = _ConstantConnectContext.Devices.Any(x=> x.RoomId == id);
                var summary = _ConstantConnectContext.RoomSummaries.FirstOrDefault(x => x.RoomId == id);

                if (crm == null)
                    return null;
                if (cc == null)
                    cc = new Entities.ConstantConnect.RoomDetail();
                if (summary == null)
                    summary = new Entities.ConstantConnect.RoomSummary();

                var room = _roomFactory.BuildRoomEntity(crm, cc, summary);
                return room;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Room GetRoomWithIncidentsAndDevices(Guid id)
        {
            try
            {
                var crm = _CRMContext.New_clientroom.Include("Incident").FirstOrDefault(x => x.New_clientroomId == id);
                var cc = _ConstantConnectContext.RoomDetails.Include("Devices").FirstOrDefault(x => x.CrmRoomId == id);
                var summary = _ConstantConnectContext.RoomSummaries.FirstOrDefault(x => x.RoomId == id);
                if (crm == null)
                    return null;
                if (cc == null)
                    cc = new Entities.ConstantConnect.RoomDetail();
                if (summary == null)
                    summary = new Entities.ConstantConnect.RoomSummary();

                var room = _roomFactory.BuildRoomEntity(crm, cc, summary);
                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IQueryable<Room> GetRooms(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            try
            {
                var list = from ar in listOfAutorizedRooms
                           select ar.RoomID;

                var crm = _CRMContext.New_clientroom.Where(r => list.Contains(r.New_clientroomId)).ToList();
                var cc = _ConstantConnectContext.RoomDetails.Where(r => list.Contains(r.CrmRoomId)).ToList();
                var summary = _ConstantConnectContext.RoomSummaries.Where(r => list.Contains(r.RoomId)).ToList();

                //var activeRooms = GetActiveRooms(userId);
                //var roomIds = activeRooms.AsEnumerable().Select(r => r.RoomID).Distinct().ToArray();

                
                //var crm = (from r in _CRMContext.New_clientroom
                //           join filtered in roomIds
                //           on r.New_clientroomId equals filtered.Value
                //           select r).Distinct().ToList();
                //var cc = (from r in _ConstantConnectContext.RoomDetails
                //          join filtered in roomIds
                //          on r.CrmRoomId equals filtered.Value
                //          select r).Distinct().ToList();
                //var summary = (from r in _ConstantConnectContext.RoomSummaries
                //               join filtered in roomIds
                //               on r.RoomId equals filtered.Value
                //               select r).Distinct().ToList();

                //var crm = _CRMContext.New_clientroom.ToList();
                //var cc = _ConstantConnectContext.RoomDetails.ToList();
                //var summary = _ConstantConnectContext.RoomSummaries.ToList();

                var room = _roomFactory.BuildRoomEntity(crm, cc, summary).AsQueryable();

                return room;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IQueryable<Room> GetRoomsWithIncidentsAndDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            try
            {
                var list = from ar in listOfAutorizedRooms
                           select ar.RoomID;
                //var activeRooms = GetActiveRooms(userId);
                //var roomIds = activeRooms.AsEnumerable().Select(r => r.RoomID).Distinct().ToArray();

                var crm = _CRMContext.New_clientroom.Include("Incident").Where(r => list.Contains(r.New_clientroomId)).ToList();
                var cc = _ConstantConnectContext.RoomDetails.Include("Devices").Where(r => list.Contains(r.CrmRoomId)).ToList();
                var summary = _ConstantConnectContext.RoomSummaries.Where(r => list.Contains(r.RoomId)).ToList();

                //var crm = (from r in _CRMContext.New_clientroom.Include("Incident")
                //           join filtered in roomIds
                //           on r.New_clientroomId equals filtered.Value
                //           select r).Distinct().ToList();
                //var cc = (from r in _ConstantConnectContext.RoomDetails
                //          join filtered in roomIds
                //          on r.CrmRoomId equals filtered.Value
                //          select r).Distinct().ToList();
                //var summary = (from r in _ConstantConnectContext.RoomSummaries
                //               join filtered in roomIds
                //               on r.RoomId equals filtered.Value
                //               select r).Distinct().ToList();

                //var crm = _CRMContext.New_clientroom.ToList();
                //var cc = _ConstantConnectContext.RoomDetails.ToList();
                //var summary = _ConstantConnectContext.RoomSummaries.ToList();

                var room = _roomFactory.BuildRoomEntity(crm, cc, summary).AsQueryable();

                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IQueryable<Room> GetRoomsWithIncidents(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            try
            {
                var list = from ar in listOfAutorizedRooms
                           select ar.RoomID;
                var crm = _CRMContext.New_clientroom.Include("Incident").Where(r => list.Contains(r.New_clientroomId)).ToList();
                var cc = _ConstantConnectContext.RoomDetails.Where(r => list.Contains(r.CrmRoomId)).ToList();
                var summary = _ConstantConnectContext.RoomSummaries.Where(r => list.Contains(r.RoomId)).ToList();
                var room = _roomFactory.BuildRoomEntity(crm, cc, summary).AsQueryable();

                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IQueryable<Room> GetRoomsWithDevices(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            try
            {
                var list = from ar in listOfAutorizedRooms
                           select ar.RoomID;
                var crm = _CRMContext.New_clientroom.Where(r => list.Contains(r.New_clientroomId)).ToList();
                var cc = _ConstantConnectContext.RoomDetails.Include("Devices").Where(r => list.Contains(r.CrmRoomId)).ToList();
                var summary = _ConstantConnectContext.RoomSummaries.Where(r => list.Contains(r.RoomId)).ToList();
                var room = _roomFactory.BuildRoomEntity(crm, cc, summary).AsQueryable();

                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

    }
}
