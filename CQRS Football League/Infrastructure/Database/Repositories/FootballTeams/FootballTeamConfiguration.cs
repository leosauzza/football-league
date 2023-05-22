using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.FootballTeams
{
    public class FootballTeamConfiguration : IEntityTypeConfiguration<FootballTeam>
    {
        public void Configure(EntityTypeBuilder<FootballTeam> builder)
        {
            builder.ToTable(nameof(FootballTeam));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);

            //Filters
            builder.HasQueryFilter(x => !x.IsDeleted);

            //Relationships
            builder.HasMany(x => x.Leagues)
                   .WithMany(x => x.Teams);
        }
    }
}
