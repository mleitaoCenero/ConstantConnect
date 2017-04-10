using ConstantConnect.Repository.Entities.ConstantConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Factories.ConstantConnect
{
    public class OrganizationFactory
    {
        OrganizationFactory org = new OrganizationFactory();
        public DTO.ConstantConnect.Organization CreateOrganization(Organization entity)
        {
            return new DTO.ConstantConnect.Organization()
            {
                OrganizationId = entity.OrganizationId,
                ParentId = entity.ParentId,
                Name = entity.Name,
                AddressLine1 = entity.AddressLine1,
                AddressLine2 = entity.AddressLine2,
                AddressLine3 = entity.AddressLine3,
                City = entity.City,
                State = entity.State,
                Zip = entity.Zip,
                Country = entity.Country,
                TimeZone = entity.TimeZone,
                Status = entity.Status,
                CreatedOn = entity.CreatedOn,
                ModifiedOn = entity.ModifiedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedBy = entity.ModifiedBy,
                PartnerId = entity.PartnerId,

                //Organization1 = entity.Organization1.Select(e=> org.CreateOrganization(e)).ToList()
            };
        }

        public Organization CreateOrganization(DTO.ConstantConnect.Organization entity)
        {
            return new Organization()
            {
                OrganizationId = entity.OrganizationId,
                ParentId = entity.ParentId,
                Name = entity.Name,
                AddressLine1 = entity.AddressLine1,
                AddressLine2 = entity.AddressLine2,
                AddressLine3 = entity.AddressLine3,
                City = entity.City,
                State = entity.State,
                Zip = entity.Zip,
                Country = entity.Country,
                TimeZone = entity.TimeZone,
                Status = entity.Status,
                CreatedOn = entity.CreatedOn,
                ModifiedOn = entity.ModifiedOn,
                CreatedBy = entity.CreatedBy,
                ModifiedBy = entity.ModifiedBy,
                PartnerId = entity.PartnerId,

                //Organization1 = entity.or.Organization1 == null ? new List<Organization>() : entity.Organization1.Select(e => org.CreateOrganization(e)).ToList()
            };
        }

    }
}
