using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.DTO.ConstantConnect
{
    using System;

    public partial class Dashboard_ActiveRooms_Result
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
        public string TimeZone { get; set; }
        public Nullable<System.Guid> RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public Nullable<int> ServicePlan { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<bool> RoomInUse { get; set; }
        public Nullable<int> VideoInUse { get; set; }
        public Nullable<int> AudioInUse { get; set; }
        public Nullable<int> ProjectorInUse { get; set; }
        public Nullable<int> MonitorInUse { get; set; }
    }
}