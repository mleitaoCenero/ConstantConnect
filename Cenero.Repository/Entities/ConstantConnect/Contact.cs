using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenero.Repository.Entities.ConstantConnect
{
    public partial class Contact
    {
        [Key]
        public System.Guid ContactID { get; set; }
        public System.Guid OrganizationID { get; set; }
        public Nullable<System.Guid> TenantID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Salutation { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public Nullable<System.Guid> PersonalContactOf { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }

        //public virtual UserAccount UserAccount { get; set; }
        //public virtual UserAccount UserAccount1 { get; set; }
    }
}
