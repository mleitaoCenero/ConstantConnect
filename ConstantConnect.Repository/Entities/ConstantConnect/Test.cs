namespace ConstantConnect.Repository.Entities.ConstantConnect
{
    public class Test
    {
        public long TestId { get; set; } // TestID (Primary key)
        public long TestTypeId { get; set; } // TestTypeID
        public string ResultType { get; set; } // ResultType (length: 50)
        public string ResultDimension { get; set; } // ResultDimension (length: 50)
        public byte SortOrder { get; set; } // SortOrder
        public string TestName { get; set; } // TestName (length: 50)
        public string TestDescription { get; set; } // TestDescription
        public short? TechLevel { get; set; } // TechLevel
        public int? Frequency { get; set; } // Frequency

        ///<summary>
        /// Link to CRM Organization ID
        ///</summary>
        public System.Guid? OwnerId { get; set; } // OwnerID
        public short? Active { get; set; } // Active
        public long? ParentTestId { get; set; } // ParentTestID

        ///<summary>
        /// character code used in URL calls to identify test
        ///</summary>
        public string UrlCode { get; set; } // URLCode (length: 50)
        public long? SubSystemId { get; set; } // SubSystemID
        public long? GenericId { get; set; } // GenericID
        public string Cavspid { get; set; } // CAVSPID (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<ActiveTestResult> ActiveTestResults { get; set; } // ActiveTestResults.FK_ActiveTestResults_Tests
        //public virtual System.Collections.Generic.ICollection<DeviceTestLink> DeviceTestLinks { get; set; } // Device_Test_Links.FK_DeviceTestLinks_Tests
        //public virtual System.Collections.Generic.ICollection<PowerResult> PowerResults { get; set; } // PowerResults.FK_PowerResults_Tests
        //public virtual System.Collections.Generic.ICollection<PowerResultsArchive> PowerResultsArchives { get; set; } // PowerResultsArchive.FK_PowerResultsArchive_Tests
        //public virtual System.Collections.Generic.ICollection<TempResult> TempResults { get; set; } // TempResults.FK_TempResults_Tests
        //public virtual System.Collections.Generic.ICollection<TempResultsArchive> TempResultsArchives { get; set; } // TempResultsArchive.FK_TempResultsArchive_Tests
        //public virtual System.Collections.Generic.ICollection<TestResult> TestResults { get; set; } // Test_Results.FK_TestResults_Tests
        //public virtual System.Collections.Generic.ICollection<TestResultsArchive> TestResultsArchives { get; set; } // TestResults_Archive.FK_TestResultsArchive_Tests

        public Test()
        {
            ActiveTestResults = new System.Collections.Generic.List<ActiveTestResult>();
            //DeviceTestLinks = new System.Collections.Generic.List<DeviceTestLink>();
            //PowerResults = new System.Collections.Generic.List<PowerResult>();
            //PowerResultsArchives = new System.Collections.Generic.List<PowerResultsArchive>();
            //TempResults = new System.Collections.Generic.List<TempResult>();
            //TempResultsArchives = new System.Collections.Generic.List<TempResultsArchive>();
            //TestResults = new System.Collections.Generic.List<TestResult>();
            //TestResultsArchives = new System.Collections.Generic.List<TestResultsArchive>();
        }
    }
}