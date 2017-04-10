using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class ActiveTestResultConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ActiveTestResult>
    {
        public ActiveTestResultConfiguration()
            : this("dbo")
        {
        }

        public ActiveTestResultConfiguration(string schema)
        {
            ToTable("ActiveTestResults", schema);
            HasKey(x => x.LineId);

            Property(x => x.LineId).HasColumnName(@"LineID").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.DeviceId).HasColumnName(@"DeviceID").HasColumnType("bigint").IsRequired();
            Property(x => x.TestId).HasColumnName(@"TestID").HasColumnType("bigint").IsRequired();
            Property(x => x.RoomId).HasColumnName(@"RoomID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.TestValue).HasColumnName(@"TestValue").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Condition).HasColumnName(@"Condition").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.MaxValue).HasColumnName(@"MaxValue").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.MinValue).HasColumnName(@"MinValue").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.ApplicationId).HasColumnName(@"ApplicationID").HasColumnType("bigint").IsOptional();
            Property(x => x.SubSystemId).HasColumnName(@"SubSystemID").HasColumnType("bigint").IsOptional();
            Property(x => x.TimeStamp).HasColumnName(@"TimeStamp").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasRequired(a => a.Device).WithMany(b => b.ActiveTestResults).HasForeignKey(c => c.DeviceId).WillCascadeOnDelete(false); // FK_ActiveTestResults_Devices
            HasRequired(a => a.Test).WithMany(b => b.ActiveTestResults).HasForeignKey(c => c.TestId).WillCascadeOnDelete(false); // FK_ActiveTestResults_Tests
        }
    }
}
