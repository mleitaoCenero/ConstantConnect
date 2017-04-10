namespace ConstantConnect.DTO.ConstantConnect
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomDetail
    {
        public System.Guid CrmRoomId { get; set; } // CRMRoomID (Primary key)
        public string RoomName { get; set; } // RoomName (length: 150)
        public string RoomDescription { get; set; } // RoomDescription (length: 250)
        public System.Guid? CrmOwnerId { get; set; } // CRMOwnerID
        public bool? RoomCheckReady { get; set; } // RoomCheckReady
        public bool? Dashboard2 { get; set; } // Dashboard_2
        public bool? Dashboard3 { get; set; } // Dashboard_3
        public long? LocationId { get; set; } // LocationID

        ///<summary>
        /// The difference in minutes between local time and UTC time
        ///</summary>
        public short? UtcOffset { get; set; } // UTCOffset

        ///<summary>
        /// The delay in minutes after midnight UTC time that testing should occur
        ///</summary>
        public short? TestOffset { get; set; } // TestOffset
        public int Status { get; set; } // Status
        public int ServicePlan { get; set; } // ServicePlan

        // Reverse navigation
        //public virtual RoomSummary RoomSummary { get; set; } // RoomSummary.FK_RoomSummary_RoomDetails
        //public virtual System.Collections.Generic.ICollection<AssignedTask> AssignedTasks { get; set; } // AssignedTasks.FK_AssignedTasks_RoomDetails
        public virtual System.Collections.Generic.ICollection<Device> Devices { get; set; } // Devices.FK_Devices_RoomDetails
    }
}
