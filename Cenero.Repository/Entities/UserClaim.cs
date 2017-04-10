using System;

namespace Cenero.Repository.Entities
{
    public class UserClaim
    {
        public Guid Id { get; set; }
        public Guid Subject { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}