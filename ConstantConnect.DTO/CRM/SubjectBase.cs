namespace ConstantConnect.DTO.CRM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SubjectBase")]
    public partial class SubjectBase
    {
        
        public SubjectBase()
        {
            //this.SubjectBase1 = new HashSet<SubjectBase>();
        }
        [Key]
        public System.Guid SubjectId { get; set; }
        public string Title { get; set; }
        public System.Guid OrganizationId { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> ParentSubject { get; set; }
        public Nullable<int> FeatureMask { get; set; }
        public Nullable<System.Guid> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public byte[] VersionNumber { get; set; }
        public Nullable<int> ImportSequenceNumber { get; set; }
        public Nullable<System.DateTime> OverriddenCreatedOn { get; set; }
        public Nullable<System.Guid> ModifiedOnBehalfBy { get; set; }
        public Nullable<System.Guid> CreatedOnBehalfBy { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SubjectBase> SubjectBase1 { get; set; }
        //public virtual SubjectBase SubjectBase2 { get; set; }
    }
}

