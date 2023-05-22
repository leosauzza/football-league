using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories.FootballLeagues
{
    public class FootballLeagueConfiguration : IEntityTypeConfiguration<FootballLeague>
    {
        public void Configure(EntityTypeBuilder<FootballLeague> builder)
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
        }
    }
}
