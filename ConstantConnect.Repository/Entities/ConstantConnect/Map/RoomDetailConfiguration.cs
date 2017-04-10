using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class RoomDetailConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RoomDetail>
    {
        public RoomDetailConfiguration()
            : this("dbo")
        {
        }

        public RoomDetailConfiguration(string schema)
        {
            ToTable("RoomDetails", schema);
            HasKey(x => x.CrmRoomId);

            Property(x => x.CrmRoomId).HasColumnName(@"CRMRoomID").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.RoomName).HasColumnName(@"RoomName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.RoomDescription).HasColumnName(@"RoomDescription").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.CrmOwnerId).HasColumnName(@"CRMOwnerID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.RoomCheckReady).HasColumnName(@"RoomCheckReady").HasColumnType("bit").IsOptional();
            Property(x => x.Dashboard2).HasColumnName(@"Dashboard_2").HasColumnType("bit").IsOptional();
            Property(x => x.Dashboard3).HasColumnName(@"Dashboard_3").HasColumnType("bit").IsOptional();
            Property(x => x.LocationId).HasColumnName(@"LocationID").HasColumnType("bigint").IsOptional();
            Property(x => x.UtcOffset).HasColumnName(@"UTCOffset").HasColumnType("smallint").IsOptional();
            Property(x => x.TestOffset).HasColumnName(@"TestOffset").HasColumnType("smallint").IsOptional();
            Property(x => x.Status).HasColumnName(@"Status").HasColumnType("int").IsRequired();
            Property(x => x.ServicePlan).HasColumnName(@"ServicePlan").HasColumnType("int").IsRequired();
        }
    }
}
