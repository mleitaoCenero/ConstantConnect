namespace ConstantConnect.Repository.Entities.CRM
{
    using System;

    public partial class Dashboard_RoomPerformance_Result
    {
        public Nullable<System.Guid> OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public Nullable<System.Guid> RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Nullable<int> OpenTicketCount { get; set; }
        public Nullable<int> ActiveTime { get; set; }
        public Nullable<int> DownTime { get; set; }
        public Nullable<int> UpTime { get; set; }
    }
}
