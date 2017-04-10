using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.Shared
{
    public class ActiveRooms
    {
        public Nullable<System.Guid> OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Nullable<System.Guid> RoomID { get; set; }
        public string RoomName { get; set; }
        

    }
}
