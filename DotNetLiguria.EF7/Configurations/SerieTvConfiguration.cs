using DotNetLiguria.EF7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetLiguria.EF7.Configurations;

internal class SerieTvConfiguration : IEntityTypeConfiguration<SerieTv>
{
    public void Configure(EntityTypeBuilder<SerieTv> builder)
    {
        // In case of TPC / TPT Mapping
        //builder.ToTable("SerieTv");

        // Remove for TPH Mapping
        builder.HasDiscriminator(x => x.SerieTV).HasValue(true);

        builder.OwnsOne(m => m.Seasons).ToJson().OwnsMany(m => m.Episodes);
    }
}