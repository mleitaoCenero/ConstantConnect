namespace ConstantConnect.DTO.ConstantConnect
{
    using System;
    using System.Collections.Generic;
    
    public partial class Device
    {
        public long DeviceId { get; set; } // DeviceID (Primary key)
        public System.Guid? RoomId { get; set; } // RoomID
        public System.Guid? EquipmentId { get; set; } // EquipmentID
        public string DeviceName { get; set; } // DeviceName (length: 100)
        public string DeviceDescription { get; set; } // DeviceDescription
        public string Model { get; set; } // Model (length: 100)
        public string SerialNumber { get; set; } // SerialNumber (length: 50)
        public long? SubSystemId { get; set; } // SubSystemID
        public string Software { get; set; } // Software (length: 50)
        public int? Lamp1 { get; set; } // Lamp1
        public int? Lamp2 { get; set; } // Lamp2
        public System.DateTime? HoldMail { get; set; } // HoldMail
        public long? Status { get; set; } // Status

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<ActiveTestResult> ActiveTestResults { get; set; } // ActiveTestResults.FK_ActiveTestResults_Devices
        //public virtual System.Collections.Generic.ICollection<CallConfigTarget> CallConfigTargets { get; set; } // CallConfigTargets.FK_CallConfigTargets_Devices
        //public virtual System.Collections.Generic.ICollection<DeviceTestLink> DeviceTestLinks { get; set; } // Device_Test_Links.FK_DeviceTestLinks_Devices
        public virtual System.Collections.Generic.ICollection<EventGroup> EventGroups { get; set; } // EventGroup.FK_EventGroup_Devices
    }
}
