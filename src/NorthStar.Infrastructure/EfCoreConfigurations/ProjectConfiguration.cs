using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.Projects;

namespace NorthStar.Infrastructure.EfCoreConfigurations;
internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("project");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .HasConversion(name => name.Value, value => new Domain.Projects.Name(value));

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.Property(x => x.BeginDate);

        builder.Property(x => x.EndDate);

        builder.HasOne(x => x.Lead);

        builder.HasMany(x => x.WorkItems);
    }
}
