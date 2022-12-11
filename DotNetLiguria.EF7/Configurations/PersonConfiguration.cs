using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF7.Configurations;

internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("People");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("PersonId");
        builder.Property(m => m.FullName).HasMaxLength(120).IsRequired();
    }
}
