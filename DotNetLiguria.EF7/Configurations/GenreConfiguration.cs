using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF7.Configurations;

internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genres");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("GenreId");
        builder.Property(m => m.Name).HasMaxLength(40).IsRequired();
    }
}
