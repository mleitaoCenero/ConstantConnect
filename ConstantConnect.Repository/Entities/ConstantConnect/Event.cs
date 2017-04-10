namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public long EventId { get; set; } // EventID (Primary key)
        public System.Guid? RoomId { get; set; } // RoomID
        public long? DeviceId { get; set; } // DeviceID
        public string EventName { get; set; } // EventName (length: 50)
        public string EventType { get; set; } // EventType (length: 50)
        public System.DateTime? EventTime { get; set; } // EventTime
        public string StartId { get; set; } // StartID (length: 50)
        public string EndId { get; set; } // EndID (length: 50)
        public short? Minuteson { get; set; } // minuteson

        ///<summary>
        /// Device id of display devices
        ///</summary>
        public long? SourceId { get; set; } // SourceID

        ///<summary>
        /// IP address of VTC call events
        ///</summary>
        public string CallId { get; set; } // CallID (length: 50)

        ///<summary>
        /// The number of minutes a source device was powering the display event
        ///</summary>
        public short? SourceOn { get; set; } // SourceOn
        public string CallNumber { get; set; } // CallNumber (length: 250)
        public string CallDisconnectReason { get; set; } // CallDisconnectReason (length: 250)
        public string CallDisconnectId { get; set; } // CallDisconnectID (length: 50)
        public long EventGroupId { get; set; } // EventGroupID

        // Foreign keys
        public virtual EventGroup EventGroup { get; set; } // FK_Events_EventGroup
    }
}
