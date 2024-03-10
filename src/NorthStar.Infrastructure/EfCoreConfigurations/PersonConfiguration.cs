using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthStar.Domain.People;

namespace NorthStar.Infrastructure.EfCoreConfigurations;
internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("people");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasConversion(x => x.Value, value => new Name(value));
        
        builder.OwnsOne(x => x.Address);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasConversion(email => email.Value, value => new Domain.People.Email(value));

        builder.Property(x => x.Role);

        builder.HasIndex(x => x.Email).IsUnique();
    }
}
