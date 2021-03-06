﻿namespace ConstantConnect.Repository.Entities.CRM
{
    using System;

    public partial class Dashboard_GetProjectFiles_Result
    {
        public System.Guid ProjectFileId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ProjectFileName { get; set; }
        public string ProjectFolderName { get; set; }
        public Nullable<System.Guid> OpportunityId { get; set; }
        public string new_sharepoint_connected_site { get; set; }
        public Nullable<System.Guid> new_CCCProgramId { get; set; }
        public Nullable<int> FileType { get; set; }
        public string FileTypeName { get; set; }
    }
}
