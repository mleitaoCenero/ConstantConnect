namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    using System;
    using System.Collections.Generic;

    public class Device
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
        //public virtual System.Collections.Generic.ICollection<EventGroupArchive> EventGroupArchives { get; set; } // EventGroupArchive.FK_EventGroupArchive_Devices
        //public virtual System.Collections.Generic.ICollection<Feedback> Feedbacks { get; set; } // Feedback.FK_Feedback_Devices
        //public virtual System.Collections.Generic.ICollection<Heartbeat> Heartbeats { get; set; } // Heartbeat.FK_Heartbeat_Devices
        //public virtual System.Collections.Generic.ICollection<PowerResult> PowerResults { get; set; } // PowerResults.FK_PowerResults_Devices
        //public virtual System.Collections.Generic.ICollection<PowerResultsArchive> PowerResultsArchives { get; set; } // PowerResultsArchive.FK_PowerResultsArchive_Devices
        //public virtual System.Collections.Generic.ICollection<TempResult> TempResults { get; set; } // TempResults.FK_TempResults_Devices
        //public virtual System.Collections.Generic.ICollection<TempResultsArchive> TempResultsArchives { get; set; } // TempResultsArchive.FK_TempResultsArchive_Devices
        //public virtual System.Collections.Generic.ICollection<TestResult> TestResults { get; set; } // Test_Results.FK_TestResults_Devices
        //public virtual System.Collections.Generic.ICollection<TestResultsArchive> TestResultsArchives { get; set; } // TestResults_Archive.FK_TestResultsArchive_Devices

        // Foreign keys
        public virtual RoomDetail RoomDetail { get; set; } // FK_Devices_RoomDetails
        //public virtual SubSystem SubSystem { get; set; } // FK_Devices_SubSystems

        public Device()
        {
            ActiveTestResults = new System.Collections.Generic.List<ActiveTestResult>();
            //CallConfigTargets = new System.Collections.Generic.List<CallConfigTarget>();
            //DeviceTestLinks = new System.Collections.Generic.List<DeviceTestLink>();
            EventGroups = new System.Collections.Generic.List<EventGroup>();
            //EventGroupArchives = new System.Collections.Generic.List<EventGroupArchive>();
            //Feedbacks = new System.Collections.Generic.List<Feedback>();
            //Heartbeats = new System.Collections.Generic.List<Heartbeat>();
            //PowerResults = new System.Collections.Generic.List<PowerResult>();
            //PowerResultsArchives = new System.Collections.Generic.List<PowerResultsArchive>();
            //TempResults = new System.Collections.Generic.List<TempResult>();
            //TempResultsArchives = new System.Collections.Generic.List<TempResultsArchive>();
            //TestResults = new System.Collections.Generic.List<TestResult>();
            //TestResultsArchives = new System.Collections.Generic.List<TestResultsArchive>();
        }
    }
}
