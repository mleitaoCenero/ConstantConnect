using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Entities.Shared;
using ConstantConnect.Repository.Factories.ConstantConnect;
using ConstantConnect.Repository.Factories.CRM;
using ConstantConnect.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConstantConnect.Repository.Factories.Shared
{
    public class RoomFactory
    {
        IncidentFactory incidentFactory = new IncidentFactory();
        DeviceFactory deviceFactory = new DeviceFactory();

        public RoomFactory()
        {

        }
        public Room BuildRoomEntity(New_clientroom crm, RoomDetail cc, RoomSummary summary)
        {
            try
            {
                var room = new Room()
                {
                    Id = crm.New_clientroomId,                                                      //From CRM New_ClientRoom > New_clientroomId
                    Name = crm.new_DisplayName == null ? crm.New_name : crm.new_DisplayName,        //From CRM New_ClientRoom > new_DisplayName
                    OrganizationId = crm.New_RoomOwnerId == null ? new Guid() : crm.New_RoomOwnerId,   //From CRM New_ClientRoom > OrganizationId
                    OrganizationName = crm.New_RoomOwnerIdName == null ? "" : crm.New_RoomOwnerIdName,//From CRM New_clientroom > OrganizationName
                    City = crm.new_City == null ? "" : crm.new_City,                                //From CRM  New_clientroom > City
                    State = crm.new_State == null ? "" : crm.new_State,                             //From CRM  New_clientroom > State
                                                                                                    //Country=crm.c //From CRM  New_clientroom > Country
                    RoomDescription = cc.RoomDescription == null ? "" : cc.RoomDescription,         //From ConstantConnect  RoomDetails > RoomDescription
                    Touchpanel = crm.new_TouchpanelWebPage,
                    VtcStatus = summary.VtcStatus == null ? 99 : summary.VtcStatus, //From ConstantConnect RoomSummary > VTCStatus
                    AtcStatus = summary.AtcStatus == null ? 99 : summary.AtcStatus, //From ConstantConnect RoomSummary >  ATCStatus
                    ControlStatus = summary.ControlStatus == null ? 99 : summary.ControlStatus, //From ConstantConnect RoomSummary >  ControlStatus
                    PresentationStatus = summary.PresentationStatus == null ? 99 : summary.PresentationStatus, //From ConstantConnect RoomSummary >  PresentationStatus
                    OnlineStatus = summary.OnlineStatus == null ? 99 : summary.OnlineStatus, //From ConstantConnect RoomSummary >  OnlineStatus
                    TestDate = summary.TestDate == null ? DateTime.Now : summary.TestDate, //From ConstantConnect RoomSummary >  TestDate
                    CrmProjectRoomId = summary.CrmProjectRoomId == null ? Guid.Empty : summary.CrmProjectRoomId, //From ConstantConnect RoomSummary >  CRM_ProjectRoomID

                    Status = cc.Status, //From ConstantConnect  RoomDetails > Status
                    ServicePlan = cc.ServicePlan, //From ConstantConnect  RoomDetails > ServicePlan

                    Incidents = crm.Incident == null ? new List<Incident>() : crm.Incident.ToList(),
                    Devices = cc.Devices == null ? new List<Device>() : cc.Devices.ToList(),
                };

                return room;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Room BuildRoomEntity(New_clientroom crm, RoomDetail cc)
        {
            try
            {
                var room = new Room()
                {
                    Id = crm.New_clientroomId,                                                      //From CRM New_ClientRoom > New_clientroomId
                    Name = crm.new_DisplayName == null ? crm.New_name : crm.new_DisplayName,        //From CRM New_ClientRoom > new_DisplayName
                    OrganizationId = crm.New_RoomOwnerId == null ? new Guid() : crm.New_RoomOwnerId,   //From CRM New_ClientRoom > OrganizationId
                    OrganizationName = crm.New_RoomOwnerIdName == null ? "" : crm.New_RoomOwnerIdName,//From CRM New_clientroom > OrganizationName
                    City = crm.new_City == null ? "" : crm.new_City,                                //From CRM  New_clientroom > City
                    State = crm.new_State == null ? "" : crm.new_State,                             //From CRM  New_clientroom > State
                                                                                                    //Country=crm.c //From CRM  New_clientroom > Country
                    RoomDescription = cc.RoomDescription == null ? "" : cc.RoomDescription,         //From ConstantConnect  RoomDetails > RoomDescription
                    Touchpanel = crm.new_TouchpanelWebPage,
                    Status = cc.Status, //From ConstantConnect  RoomDetails > Status
                    ServicePlan = cc.ServicePlan, //From ConstantConnect  RoomDetails > ServicePlan

                    Incidents = crm.Incident == null ? new List<Incident>() : crm.Incident.ToList(),
                    Devices = cc.Devices == null ? new List<Device>() : cc.Devices.ToList()
                };

                return room;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public DTO.Shared.Room CreateRoom(Room entity)
        {
            return new DTO.Shared.Room()
            {
                Id = entity.Id,  //From CRM New_ClientRoom > New_clientroomId
                Name = entity.Name,//From CRM New_ClientRoom > new_DisplayName
                OrganizationId = entity.OrganizationId, //From CRM New_ClientRoom > OrganizationId
                OrganizationName = entity.OrganizationName, //From CRM New_clientroom > OrganizationName
                City = entity.City, //From CRM  New_clientroom > City
                State = entity.State, //From CRM  New_clientroom > State
                //Country=crm.c //From CRM  New_clientroom > Country
                RoomDescription = entity.RoomDescription, //From ConstantConnect  RoomDetails > RoomDescription
                Touchpanel = entity.Touchpanel,
                VtcStatus = entity.VtcStatus, //From ConstantConnect RoomSummary > VTCStatus
                AtcStatus = entity.AtcStatus, //From ConstantConnect RoomSummary >  ATCStatus
                ControlStatus = entity.ControlStatus, //From ConstantConnect RoomSummary >  ControlStatus
                PresentationStatus = entity.PresentationStatus, //From ConstantConnect RoomSummary >  PresentationStatus
                OnlineStatus = entity.OnlineStatus, //From ConstantConnect RoomSummary >  OnlineStatus
                TestDate = entity.TestDate, //From ConstantConnect RoomSummary >  TestDate
                CrmProjectRoomId = entity.CrmProjectRoomId, //From ConstantConnect RoomSummary >  CRM_ProjectRoomID

                Status = entity.Status, //From ConstantConnect  RoomDetails > Status
                ServicePlan = entity.ServicePlan, //From ConstantConnect  RoomDetails > ServicePlan

                Incidents = entity.Incidents.Select(e => incidentFactory.CreateIncident(e)).ToList(),
                Devices = entity.Devices.Select(e => deviceFactory.CreateDevice(e)).ToList()
            };
        }

        

        public Room CreateRoom(DTO.Shared.Room entity)
        {
            return new Room()
            {
                Id = entity.Id,  //From CRM New_ClientRoom > New_clientroomId
                Name = entity.Name,//From CRM New_ClientRoom > new_DisplayName
                OrganizationId = entity.OrganizationId, //From CRM New_ClientRoom > OrganizationId
                OrganizationName = entity.OrganizationName, //From CRM New_clientroom > OrganizationName
                City = entity.City, //From CRM  New_clientroom > City
                State = entity.State, //From CRM  New_clientroom > State
                //Country=crm.c //From CRM  New_clientroom > Country
                RoomDescription = entity.RoomDescription, //From ConstantConnect  RoomDetails > RoomDescription
                Touchpanel = entity.Touchpanel,
                VtcStatus = entity.VtcStatus, //From ConstantConnect RoomSummary > VTCStatus
                AtcStatus = entity.AtcStatus, //From ConstantConnect RoomSummary >  ATCStatus
                ControlStatus = entity.ControlStatus, //From ConstantConnect RoomSummary >  ControlStatus
                PresentationStatus = entity.PresentationStatus, //From ConstantConnect RoomSummary >  PresentationStatus
                OnlineStatus = entity.OnlineStatus, //From ConstantConnect RoomSummary >  OnlineStatus
                TestDate = entity.TestDate, //From ConstantConnect RoomSummary >  TestDate
                CrmProjectRoomId = entity.CrmProjectRoomId, //From ConstantConnect RoomSummary >  CRM_ProjectRoomID

                Status = entity.Status, //From ConstantConnect  RoomDetails > Status
                ServicePlan = entity.ServicePlan, //From ConstantConnect  RoomDetails > ServicePlan

                Incidents = entity.Incidents == null ? new List<Incident>() : entity.Incidents.Select(e => incidentFactory.CreateIncident(e)).ToList(),
                Devices = entity.Devices == null ? new List<Device>() : entity.Devices.Select(e => deviceFactory.CreateDevice(e)).ToList()
            };
        }

        public object CreateDataShapedObject(Room x, List<string> listOfFields)
        {
            return CreateDataShapedObject(CreateRoom(x), listOfFields);
        }

        public object CreateDataShapedObject(DTO.Shared.Room x, List<string> listOfFields)
        {
            var listOfFieldsToWorkWith = new List<string>(listOfFields);

            if (!listOfFieldsToWorkWith.Any())
                return x;

            var listOfIncidentFields = listOfFieldsToWorkWith.Where(f => f.Contains("incident")).ToList();
            //var listOfNew_clientequipmemtipdataFields = listOfFieldsToWorkWith.Where(f => f.Contains("new_clientequipmemtipdata")).ToList();
            var listOfDeviceFields = listOfFieldsToWorkWith.Where(f => f.Contains("device")).ToList();

            bool returnPartialIncident = listOfIncidentFields.Any() && !listOfIncidentFields.Contains("incident");
            bool returnPartialDevice = listOfDeviceFields.Any() && !listOfDeviceFields.Contains("device");
            //bool returnPartialNew_clientequipmemtipdata = listOfIncidentFields.Any() && !listOfNew_clientequipmemtipdataFields.Contains("new_clientequipmemtipdata");

            if (returnPartialIncident)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfIncidentFields);
                listOfIncidentFields = listOfIncidentFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfIncidentFields.Remove("incident");
                listOfFieldsToWorkWith.RemoveRange(listOfIncidentFields);
            }

            if(returnPartialDevice)
            {
                listOfFieldsToWorkWith.RemoveRange(listOfDeviceFields);
                listOfDeviceFields = listOfDeviceFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();
            }
            else
            {
                listOfDeviceFields.Remove("device");
                listOfFieldsToWorkWith.RemoveRange(listOfDeviceFields);
            }

            ExpandoObject result = new ExpandoObject();
            foreach (var field in listOfFieldsToWorkWith)
            {
                var fieldValue = x.GetType()
                    .GetProperty(field, System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                    .GetValue(x, null);

                ((IDictionary<String, Object>)result).Add(field, fieldValue);
            }

            if (returnPartialIncident)
            {
                var incidents = new List<object>();
                foreach (var incident in x.Incidents)
                {
                    incidents.Add(incidentFactory.CreateDataShapedObject(incident, listOfIncidentFields));
                }
                ((IDictionary<String, Object>)result).Add("Incidents", incidents);
            }

            if (returnPartialDevice)
            {
                var data = new List<object>();
                foreach (var n in x.Devices)
                {
                    data.Add(deviceFactory.CreateDataShapedObject(n, listOfDeviceFields));
                }
                ((IDictionary<String, Object>)result).Add("devices", data);
            }

            return result;
        }

        public List<Room> BuildRoomEntity(List<New_clientroom> crm, List<RoomDetail> cc, List<RoomSummary> summary)
        {
            List<Room> rooms = new List<Room>();
            using(var room = crm.GetEnumerator())
            using(var roomDetails = cc.GetEnumerator())
            using(var sum = summary.GetEnumerator())
            {
                while(room.MoveNext())
                {
                    roomDetails.MoveNext();
                    sum.MoveNext();
                    rooms.Add(BuildRoomEntity(room.Current, roomDetails.Current == null ? new RoomDetail() : roomDetails.Current,
                        sum.Current==null ? new RoomSummary() : sum.Current));
                }
            } 
            return rooms;
        }
    }
}
