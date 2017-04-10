using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class EventGroupConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<EventGroup>
    {
        public EventGroupConfiguration()
            : this("dbo")
        {
        }

        public EventGroupConfiguration(string schema)
        {
            ToTable("EventGroup", schema);
            HasKey(x => x.EventGroupId);

            Property(x => x.EventGroupId).HasColumnName(@"EventGroupID").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.StartCode).HasColumnName(@"StartCode").HasColumnType("datetime").IsRequired();
            Property(x => x.StartId).HasColumnName(@"StartID").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.EndId).HasColumnName(@"EndID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.DeviceId).HasColumnName(@"DeviceID").HasColumnType("bigint").IsRequired();
            Property(x => x.EventStart).HasColumnName(@"EventStart").HasColumnType("datetime").IsOptional();
            Property(x => x.EventEnd).HasColumnName(@"EventEnd").HasColumnType("datetime").IsOptional();
            Property(x => x.MinutesOn).HasColumnName(@"MinutesOn").HasColumnType("bigint").IsOptional();
            Property(x => x.CallNumber).HasColumnName(@"CallNumber").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.CallDisconnectReason).HasColumnName(@"CallDisconnectReason").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);

            // Foreign keys
            HasRequired(a => a.Device).WithMany(b => b.EventGroups).HasForeignKey(c => c.DeviceId).WillCascadeOnDelete(false); // FK_EventGroup_Devices
        }
    }
}
