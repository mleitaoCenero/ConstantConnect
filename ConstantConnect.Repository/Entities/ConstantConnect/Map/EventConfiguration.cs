using System.Data.Entity.ModelConfiguration;

namespace ConstantConnect.Repository.Entities.ConstantConnect.Map
{
    public class EventConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
            : this("dbo")
        {
        }

        public EventConfiguration(string schema)
        {
            ToTable("Events", schema);
            HasKey(x => x.EventId);

            Property(x => x.EventId).HasColumnName(@"EventID").HasColumnType("bigint").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoomId).HasColumnName(@"RoomID").HasColumnType("uniqueidentifier").IsOptional();
            Property(x => x.DeviceId).HasColumnName(@"DeviceID").HasColumnType("bigint").IsOptional();
            Property(x => x.EventName).HasColumnName(@"EventName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.EventType).HasColumnName(@"EventType").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.EventTime).HasColumnName(@"EventTime").HasColumnType("datetime").IsOptional();
            Property(x => x.StartId).HasColumnName(@"StartID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.EndId).HasColumnName(@"EndID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Minuteson).HasColumnName(@"minuteson").HasColumnType("smallint").IsOptional();
            Property(x => x.SourceId).HasColumnName(@"SourceID").HasColumnType("bigint").IsOptional();
            Property(x => x.CallId).HasColumnName(@"CallID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.SourceOn).HasColumnName(@"SourceOn").HasColumnType("smallint").IsOptional();
            Property(x => x.CallNumber).HasColumnName(@"CallNumber").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.CallDisconnectReason).HasColumnName(@"CallDisconnectReason").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.CallDisconnectId).HasColumnName(@"CallDisconnectID").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.EventGroupId).HasColumnName(@"EventGroupID").HasColumnType("bigint").IsRequired();

            // Foreign keys
            HasRequired(a => a.EventGroup).WithMany(b => b.Events).HasForeignKey(c => c.EventGroupId).WillCascadeOnDelete(false); // FK_Events_EventGroup
        }
    }
}