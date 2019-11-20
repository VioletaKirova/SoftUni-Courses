namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.Property(t => t.Initials)
                .HasColumnType("CHAR(3)");

            builder.HasMany(t => t.HomeGames)
                .WithOne(g => g.HomeTeam)
                .HasForeignKey(g => g.HomeTeamId);

            builder.HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam)
                .HasForeignKey(g => g.AwayTeamId);

            builder.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);
        }
    }
}
