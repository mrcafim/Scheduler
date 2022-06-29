using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduler.Web.Domain.Events.Entities;

namespace Scheduler.Web.Infra.Data.Mappings
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.Property(x => x.Active).IsRequired();

            builder.Property(x => x.Deleted).IsRequired();

            builder.Property(x => x.StartDate).IsRequired();

            builder.Property(x => x.EndDate).IsRequired();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(100)")
                .HasColumnName("Title")
                .IsRequired();

            builder.Property(x => x.Location)
                 .HasColumnType("varchar(100)")
                 .HasColumnName("Location");

            builder.Property(x => x.Description)
                 .HasMaxLength(200);
        }
    }
}
