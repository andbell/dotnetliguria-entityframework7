using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF7.Configurations;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).HasColumnName("MovieId");
        builder.Property(m => m.Title).HasMaxLength(250).IsRequired();

        builder.Property("ComputedYear").HasComputedColumnSql("JSON_VALUE(Info, '$.Year')");
        builder.HasIndex("ComputedYear");

        builder.OwnsOne(m => m.Cast, cast =>
        {
            cast.ToJson();
            cast.OwnsMany(c => c.Actors);
            cast.OwnsMany(c => c.Directors);
        });

        builder.OwnsOne(m => m.Info, info =>
        {
            info.ToJson();
        });


        // Remove for TPC
        builder.HasDiscriminator(x => x.SerieTV).HasValue(false);

        builder.UseTphMappingStrategy();
        //builder.UseTpcMappingStrategy();
        // builder.UseTptMappingStrategy();
    }
}
