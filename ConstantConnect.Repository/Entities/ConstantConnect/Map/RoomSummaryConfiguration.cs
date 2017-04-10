using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class RoomSummaryConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RoomSummary>
    {
        public RoomSummaryConfiguration()
            : this("dbo")
        {
        }

        public RoomSummaryConfiguration(string schema)
        {
            ToTable("RoomSummary", schema);
            HasKey(x => x.RoomId);

            Property(x => x.LineId).HasColumnName(@"LineID").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoomId).HasColumnName(@"RoomID").HasColumnType("uniqueidentifier").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.RoomName).HasColumnName(@"RoomName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(75);
            Property(x => x.VtcStatus).HasColumnName(@"VTCStatus").HasColumnType("smallint").IsOptional();
            Property(x => x.AtcStatus).HasColumnName(@"ATCStatus").HasColumnType("smallint").IsOptional();
            Property(x => x.ControlStatus).HasColumnName(@"ControlStatus").HasColumnType("smallint").IsOptional();
            Property(x => x.PresentationStatus).HasColumnName(@"PresentationStatus").HasColumnType("smallint").IsOptional();
            Property(x => x.OnlineStatus).HasColumnName(@"OnlineStatus").HasColumnType("smallint").IsOptional();
            Property(x => x.TestDate).HasColumnName(@"TestDate").HasColumnType("datetime").IsOptional();
            Property(x => x.CrmProjectRoomId).HasColumnName(@"CRM_ProjectRoomID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.RoomViewRoomId).HasColumnName(@"RoomView_RoomID").HasColumnType("uniqueidentifier").IsOptional();

            // Foreign keys
            HasRequired(a => a.RoomDetail).WithOptional(b => b.RoomSummary).WillCascadeOnDelete(false); // FK_RoomSummary_RoomDetails
        }
    }
}
