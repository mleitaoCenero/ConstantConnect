using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.DTO.CRM
{
    using System;

    public partial class Dashboard_ServiceTicketTrends_Result
    {
        public Nullable<System.Guid> RoomID { get; set; }
        public string RoomName { get; set; }
        public Nullable<System.Guid> SubjectID { get; set; }
        public string SubjectName { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<int> TicketCount { get; set; }
    }
}
