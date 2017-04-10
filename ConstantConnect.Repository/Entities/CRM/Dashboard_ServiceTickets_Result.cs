namespace ConstantConnect.Repository.Entities.CRM
{
    using System;

    public partial class Dashboard_ServiceTickets_Result
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
        public System.Guid TicketID { get; set; }
        public string TicketNumber { get; set; }
        public Nullable<System.DateTime> TicketCreatedOn { get; set; }
        public string TicketSubject { get; set; }
        public string TicketStatus { get; set; }
        public Nullable<int> TicketStatusCode { get; set; }
        public string TicketState { get; set; }
        public int TicketStateCode { get; set; }
    }
}
