using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using ConstantConnect.Repository.Entities.ConstantConnect;
using ConstantConnect.Repository.Entities.ConstantConnect.Map;

namespace ConstantConnect.Repository.Entities.Contexts
{
    public partial class ConstantConnectContext : DbContext
    {
        public ConstantConnectContext()
            : base("name=ConstantConnectEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ActiveTestResultConfiguration());
            modelBuilder.Configurations.Add(new DeviceConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new EventGroupConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new RoomDetailConfiguration());
            modelBuilder.Configurations.Add(new RoomSummaryConfiguration());
        }


        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<EventGroup> EventGroups { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<RoomDetail> RoomDetails { get; set; }
        public virtual DbSet<RoomSummary> RoomSummaries { get; set; }
        //Stored Procedures
        public virtual ObjectResult<Dashboard_ActiveRooms_Result> Dashboard_ActiveRooms(Nullable<System.Guid> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Dashboard_ActiveRooms_Result>("Dashboard_ActiveRooms", userIDParameter);
        }
    }
}
