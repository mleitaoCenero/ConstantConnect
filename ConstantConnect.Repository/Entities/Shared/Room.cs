
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.CRM;
using System;
using System.Collections.Generic;

namespace ConstantConnect.Repository.Entities.Shared
{
    public class Room
    {
        public Room()
        {
            this.Incidents = new List<Incident>();
            this.Devices = new List<Device>();
        }

        public System.Guid Id { get; set; } //From CRM New_ClientRoom > New_clientroomId
        public string Name { get; set; } //From CRM New_ClientRoom > new_DisplayName
        public Nullable<System.Guid> OrganizationId { get; set; } //From CRM New_ClientRoom > OrganizationId
        public string OrganizationName { get; set; } //From CRM New_clientroom > OrganizationName
        public string City { get; set; } //From CRM  New_clientroom > City
        public string State { get; set; } //From CRM  New_clientroom > State
        //public string Country { get; set; } //From CRM  New_clientroom > Country
        public string RoomDescription { get; set; } //From ConstantConnect  RoomDetails > RoomDescription
        public string Touchpanel { get; set; } //From CRM New_clientroom > new_TouchpanelWebPage

        public short? VtcStatus { get; set; } //From ConstantConnect RoomSummary > VTCStatus
        public short? AtcStatus { get; set; } //From ConstantConnect RoomSummary >  ATCStatus
        public short? ControlStatus { get; set; } //From ConstantConnect RoomSummary >  ControlStatus
        public short? PresentationStatus { get; set; } //From ConstantConnect RoomSummary >  PresentationStatus
        public short? OnlineStatus { get; set; } //From ConstantConnect RoomSummary >  OnlineStatus
        public System.DateTime? TestDate { get; set; } //From ConstantConnect RoomSummary >  TestDate
        public System.Guid? CrmProjectRoomId { get; set; } //From ConstantConnect RoomSummary >  CRM_ProjectRoomID
        //public System.Guid? RoomViewRoomId { get; set; } // RoomView_RoomID

        public int? Status { get; set; } //From ConstantConnect  RoomDetails > Status
        public int? ServicePlan { get; set; } //From ConstantConnect  RoomDetails > ServicePlan

        public List<Incident> Incidents { get; set; } //From CRM New_ClientRoom > Incidents
        public List<Device> Devices { get; set; } //From ConstantConnect  RoomDetails > Devices



    }
}
