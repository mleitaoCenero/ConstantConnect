namespace ConstantConnect.DTO.ConstantConnect
{
    using System;
    using System.Collections.Generic;
    
    public partial class EventGroup
    {
        public long EventGroupId { get; set; } // EventGroupID (Primary key)
        public System.DateTime StartCode { get; set; } // StartCode
        public string StartId { get; set; } // StartID (length: 50)
        public string EndId { get; set; } // EndID (length: 50)
        public long DeviceId { get; set; } // DeviceID
        public System.DateTime? EventStart { get; set; } // EventStart
        public System.DateTime? EventEnd { get; set; } // EventEnd
        public long? MinutesOn { get; set; } // MinutesOn
        public string CallNumber { get; set; } // CallNumber (length: 250)
        public string CallDisconnectReason { get; set; } // CallDisconnectReason (length: 250)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Event> Events { get; set; } // Events.FK_Events_EventGroup

    }
}
