using Core.Domain.Entities;
using Core.Domain.Entities.Shared;
using Infrastructure.Database.Repositories.FootballLeagues;
using Infrastructure.Database.Repositories.FootballPlayers;
using Infrastructure.Database.Repositories.FootballTeams;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context
{
    public class CQRSFootballLeagueDBContext : DbContext
    {
        public CQRSFootballLeagueDBContext(DbContextOptions<CQRSFootballLeagueDBContext> options)
            : base(options) { }

        public DbSet<FootballPlayer> FootballPlayers { get; set; }
        public DbSet<FootballLeague> FootballLeagues { get; set; }
        public DbSet<FootballTeam>  FootballTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new FootballPlayerConfiguration());
            modelBuilder.ApplyConfiguration(new FootballTeamConfiguration());
            modelBuilder.ApplyConfiguration(new FootballLeagueConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property(nameof(Entity<int>.CreatedDate)).CurrentValue = DateTime.Now;
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property(nameof(Entity<int>.UpdatedDate)).CurrentValue = DateTime.Now;
            });

            return base.SaveChangesAsync();

        }
    }
}
