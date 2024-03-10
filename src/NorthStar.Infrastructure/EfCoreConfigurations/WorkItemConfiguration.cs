using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.WorkItems;

namespace NorthStar.Infrastructure.EfCoreConfigurations;
internal sealed class WorkItemConfiguration : IEntityTypeConfiguration<WorkItem>
{
    public void Configure(EntityTypeBuilder<WorkItem> builder)
    {
        builder.ToTable("workitem");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Project);

        builder.Property(x => x.Summary)
            .HasConversion(x => x.Value, value => new Summary(value));

        builder.Property(x => x.Description)
            .HasConversion(x => x.Value, value => new Description(value));

        builder.Property(x => x.Priority);

        builder.Property(x => x.Resolution);

        builder.HasOne(x => x.Assignee);

        builder.HasOne(x => x.Reporter);

        builder.Property(x => x.Status);

        builder.Property(x => x.BeginDate);

        builder.Property(x => x.EndDate);

        builder.Property<uint>("version").IsRowVersion();
    }
}
