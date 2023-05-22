using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Repositories.FootballPlayers
{
    public class FootballPlayerConfiguration : IEntityTypeConfiguration<FootballPlayer>
    {
        public void Configure(EntityTypeBuilder<FootballPlayer> builder)
        {
            builder.ToTable(nameof(FootballPlayer));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);

            //Filters
            builder.HasQueryFilter(x => !x.IsDeleted);

            //Relationships
            builder.HasOne(x => x.Team)
                   .WithMany(x => x.Players)
                   .HasForeignKey(x => x.TeamId);
        }
    }
}
