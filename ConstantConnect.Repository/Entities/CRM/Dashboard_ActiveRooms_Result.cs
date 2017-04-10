namespace ConstantConnect.Repository.Entities.CRM
{
    using System;

    public partial class Dashboard_ActiveRooms_Result
    {
        public System.Guid OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public System.Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public string ServicePlan { get; set; }
    }
}

