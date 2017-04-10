using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class DeviceConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Device>
    {
        public DeviceConfiguration()
            : this("dbo")
        {
        }

        public DeviceConfiguration(string schema)
        {
            ToTable("Devices", schema);
            HasKey(x => x.DeviceId);

            Property(x => x.DeviceId).HasColumnName(@"DeviceID").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoomId).HasColumnName(@"RoomID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.EquipmentId).HasColumnName(@"EquipmentID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.DeviceName).HasColumnName(@"DeviceName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.DeviceDescription).HasColumnName(@"DeviceDescription").HasColumnType("varchar(max)").IsOptional().IsUnicode(false);
            Property(x => x.Model).HasColumnName(@"Model").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.SerialNumber).HasColumnName(@"SerialNumber").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.SubSystemId).HasColumnName(@"SubSystemID").HasColumnType("bigint").IsOptional();
            Property(x => x.Software).HasColumnName(@"Software").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Lamp1).HasColumnName(@"Lamp1").HasColumnType("int").IsOptional();
            Property(x => x.Lamp2).HasColumnName(@"Lamp2").HasColumnType("int").IsOptional();
            Property(x => x.HoldMail).HasColumnName(@"HoldMail").HasColumnType("datetime").IsOptional();
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("bigint").IsOptional();

            // Foreign keys
            HasOptional(a => a.RoomDetail).WithMany(b => b.Devices).HasForeignKey(c => c.RoomId).WillCascadeOnDelete(false); // FK_Devices_RoomDetails
            //HasOptional(a => a.SubSystem).WithMany(b => b.Devices).HasForeignKey(c => c.SubSystemId).WillCascadeOnDelete(false); // FK_Devices_SubSystems
        }
    }
}
