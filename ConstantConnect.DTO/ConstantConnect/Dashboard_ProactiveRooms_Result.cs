using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.DTO.ConstantConnect
{
    public partial class Dashboard_ProactiveRooms_Result
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
        public string TimeZone { get; set; }
        public System.Guid RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Nullable<System.DateTime> TestDate { get; set; }
        public Nullable<int> OnlineStatus { get; set; }
        public Nullable<int> VTCStatus { get; set; }
        public Nullable<int> ATCStatus { get; set; }
        public Nullable<int> PresentationStatus { get; set; }
        public Nullable<int> ControlStatus { get; set; }
    }
}
