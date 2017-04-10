using System;
using System.Collections.Generic;
using Cenero.Repository.Entities;

namespace Cenero.Repository
{
    public interface IUserRepository
    {
        void Dispose();
        User GetUser(string subject);
        User GetUser(string userName, string password);
        IList<UserClaim> GetUserClaims(string subject);
        IList<UserLogins> GetUserLogins(string subject);
    }
}