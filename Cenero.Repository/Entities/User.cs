using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenero.Repository.Entities
{
    public class User
    {
        public string Subject { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool DashboardAccess { get; set; }
        public bool DashboardAdmin { get; set; }
        public bool DashboardFinancial { get; set; }
        public bool DashboardSuper { get; set; }
        public bool RoomCheckAccess { get; set; }
        public bool RoomCheckTechnician { get; set; }
        public bool RoomCheckManager { get; set; }
        public bool RoomCheckAdmin { get; set; }
        public bool RoomCheckCommission { get; set; }
        public Guid OrganizationId { get; set; }
        public IList<UserClaim> UserClaims { get; set; }
        public IList<UserLogins> UserLogins { get; set; }

        public User()
        {
            UserClaims = new List<UserClaim>();
            UserLogins = new List<UserLogins>();
        }
    }
}
