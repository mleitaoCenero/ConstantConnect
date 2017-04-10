namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    public class ActiveTestResult
    {
        public long LineId { get; set; } // LineID (Primary key)
        public long DeviceId { get; set; } // DeviceID
        public long TestId { get; set; } // TestID
        public System.Guid? RoomId { get; set; } // RoomID
        public string TestValue { get; set; } // TestValue (length: 50)
        public string Condition { get; set; } // Condition (length: 50)
        public string MaxValue { get; set; } // MaxValue (length: 50)
        public string MinValue { get; set; } // MinValue (length: 50)
        public long? ApplicationId { get; set; } // ApplicationID
        public long? SubSystemId { get; set; } // SubSystemID
        public System.DateTime? TimeStamp { get; set; } // TimeStamp

        // Foreign keys
        public virtual Device Device { get; set; } // FK_ActiveTestResults_Devices
        public virtual Test Test { get; set; } // FK_ActiveTestResults_Tests
    }
}