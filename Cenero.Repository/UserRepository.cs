using Cenero.Repository.Entities;
using Cenero.Repository.Entities.ConstantConnect;
using Cenero.Repository.Entities.Contexts;
using Cenero.Repository.Helpers;
using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cenero.Repository
{
    public class UserRepository : IDisposable, IUserRepository
    {
        ConstantConnectContext _userContext;

        #region Constructors

        public UserRepository(ConstantConnectContext userContext)
        {
            _userContext = userContext;
        }

        public UserRepository()
        {
            _userContext = new ConstantConnectContext();
        }

        #endregion

        #region IUserRepository

        public User GetUser(string subject)
        {
            var account = _userContext.User_GetByID(Guid.Parse(subject));
            if (account != null && account.Status == 1)
            {
                User user = new Entities.User()
                {
                    Subject = account.UserID.ToString(),
                    UserName = account.UserName,
                    Password = account.Password,
                    IsActive = account.Status == 1,
                    DashboardAccess = account.DashboardAccess,
                    DashboardAdmin = account.Dashboard_Admin,
                    DashboardFinancial = account.Dashboard_Financial,
                    DashboardSuper = account.Dashboard_Super,
                    RoomCheckAccess = account.RoomCheckAccess,
                    RoomCheckTechnician = account.RoomCheck_Technician,
                    RoomCheckManager = account.RoomCheck_Manager,
                    RoomCheckAdmin = account.RoomCheck_Admin,
                    RoomCheckCommission = account.RoomCheck_Commissioning,
                    OrganizationId = account.OrganizationID,
                    UserClaims = new List<UserClaim>()
                    {
                        new UserClaim()
                        {
                            Id = Guid.NewGuid(),
                            Subject = account.UserID,
                            ClaimType = JwtClaimTypes.GivenName,
                            ClaimValue = account.FirstName
                        },
                        new UserClaim()
                        {
                            Id= Guid.NewGuid(),
                            Subject=account.UserID,
                            ClaimType = JwtClaimTypes.FamilyName,
                            ClaimValue = account.LastName
                        },
                        new UserClaim()
                        {
                            Id= Guid.NewGuid(),
                            Subject=account.UserID,
                            ClaimType = JwtClaimTypes.Email,
                            ClaimValue = account.Email
                        }

                    },
                    UserLogins = new List<UserLogins>() { }
                };
                return user;
            }
            return null;
        }

        public User GetUser(string userName, string password)
        {
            var account = _userContext.User_Validate(userName, password);
            if (account != null && account.Status == 1)
            {
                User user = new Entities.User()
                {
                    Subject = account.UserID.ToString(),
                    UserName = account.UserName,
                    Password = account.Password,
                    IsActive = account.Status == 1,
                    DashboardAccess = account.DashboardAccess,
                    DashboardAdmin = account.Dashboard_Admin,
                    DashboardFinancial = account.Dashboard_Financial,
                    DashboardSuper = account.Dashboard_Super,
                    RoomCheckAccess = account.RoomCheckAccess,
                    RoomCheckTechnician = account.RoomCheck_Technician,
                    RoomCheckManager = account.RoomCheck_Manager,
                    RoomCheckAdmin = account.RoomCheck_Admin,
                    RoomCheckCommission = account.RoomCheck_Commissioning,
                    OrganizationId = account.OrganizationID,
                    UserClaims = new List<UserClaim>()
                    {
                        new UserClaim()
                        {
                            Id = Guid.NewGuid(),
                            Subject = account.UserID,
                            ClaimType = JwtClaimTypes.GivenName,
                            ClaimValue = account.FirstName
                        },
                        new UserClaim()
                        {
                            Id= Guid.NewGuid(),
                            Subject=account.UserID,
                            ClaimType = JwtClaimTypes.FamilyName,
                            ClaimValue = account.LastName
                        },
                        new UserClaim()
                        {
                            Id= Guid.NewGuid(),
                            Subject=account.UserID,
                            ClaimType = JwtClaimTypes.Email,
                            ClaimValue = account.Email
                        }

                    },
                    UserLogins = new List<UserLogins>() { }
                };
                return user;
            }
            return null;
        }

        public IList<UserClaim> GetUserClaims(string subject)
        {
            var user = GetUser(subject);
            if (user == null)
                return new List<UserClaim>();

            return user.UserClaims;
        }

        public IList<UserLogins> GetUserLogins(string subject)
        {
            var user = GetUser(subject);
            if (user == null)
                return new List<UserLogins>();

            return user.UserLogins;
        }

        

        //public UserAccount GetUser(string userName, string password)
        //{
        //    var account = _userContext.UserAccounts.First(u => u.UserName == userName);

        //    if (account != null)
        //    {
        //        if (Validate.ValidatePassword(password, account.Password))
        //            return account;
        //    }
        //    return null;
        //    //return _userContext.UserAccounts.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        //}



        //public IQueryable<Contact> GetUserContacts(Guid subject)
        //{
        //    return _userContext.Contacts.Where(c => c.PersonalContactOf == subject);
        //}

        //public bool DoesUserHaveClaim(Guid subject, Claim claim)
        //{
        //    var result = _userContext.UserAccounts.FirstOrDefault(u => u.UserID == subject);
        //    switch (claim)
        //    {
        //        case Claim.DashboardAccess:
        //            return result.DashboardAccess;
        //        case Claim.Dashboard_Admin:
        //            return result.Dashboard_Admin;
        //        case Claim.Dashboard_Financial:
        //            return result.Dashboard_Financial;
        //        case Claim.Dashboard_Super:
        //            return result.Dashboard_Super;
        //        case Claim.RoomCheckAccess:
        //            return result.RoomCheckAccess;
        //        case Claim.RoomCheck_Admin:
        //            return result.RoomCheck_Admin;
        //        case Claim.RoomCheck_Commissioning:
        //            return result.RoomCheck_Commissioning;
        //        case Claim.RoomCheck_Manager:
        //            return result.RoomCheck_Manager;
        //        case Claim.RoomCheck_Technician:
        //            return result.RoomCheck_Technician;
        //        default:
        //            return false;
        //    }
        //}

        //public Contact GetUserDetails(Guid subject)
        //{
        //    return _userContext.Contacts.FirstOrDefault(c => c.ContactID == subject);
        //}

        #endregion

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userContext != null)
                {
                    _userContext.Dispose();
                    _userContext = null;
                }
            }
        }

        


        #endregion
    }
}
