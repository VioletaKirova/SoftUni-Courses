namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.ColorId);

            builder.HasMany(c => c.PrimaryKitTeams)
                .WithOne(t => t.PrimaryKitColor)
                .HasForeignKey(t => t.PrimaryKitColorId);

            builder.HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor)
                .HasForeignKey(t => t.SecondaryKitColorId);
        }
    }
}
