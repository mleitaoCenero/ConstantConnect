using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenero.Repository.Entities.ConstantConnect
{
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            //this.Contacts = new HashSet<Contact>();
        }
        [Key]
        public System.Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool PasswordMustChange { get; set; }
        public bool FirstLogIn { get; set; }
        public int AuralinkAccess { get; set; }
        public bool DashboardAccess { get; set; }
        public bool Dashboard_Admin { get; set; }
        public bool Dashboard_Financial { get; set; }
        public bool Dashboard_Super { get; set; }
        public bool RoomCheckAccess { get; set; }
        public bool RoomCheck_Technician { get; set; }
        public bool RoomCheck_Manager { get; set; }
        public bool RoomCheck_Admin { get; set; }
        public bool RoomCheck_Commissioning { get; set; }
        public int EventSchedulerAccess { get; set; }
        public int Status { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public System.Guid CreatedBy { get; set; }
        public Nullable<System.Guid> ModifiedBy { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        
        //public virtual ICollection<Contact> Contacts { get; set; }
        //[ForeignKey("ContactID")]
        //public virtual Contact Contact { get; set; }
    }
}
