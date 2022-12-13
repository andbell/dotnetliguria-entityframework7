using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF7.Configurations;

internal class SerieTvConfiguration : IEntityTypeConfiguration<SerieTv>
{
    public void Configure(EntityTypeBuilder<SerieTv> builder)
    {
        builder.HasDiscriminator(x => x.SerieTV).HasValue(true);
        builder.OwnsOne(m => m.Seasons).ToJson().OwnsMany(m => m.Episodes);
    }
}