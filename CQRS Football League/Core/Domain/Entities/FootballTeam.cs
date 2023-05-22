using Core.Domain.Entities.Shared;

namespace Core.Domain.Entities
{
    public class FootballTeam : Entity<int>
    {
        public string Name { get; private set; }
        public virtual ICollection<FootballPlayer> Players { get; private set; }
        public virtual ICollection<FootballLeague> Leagues { get; private set; }

        public FootballTeam()
        {

        }

        public FootballTeam(int id, string name, bool isDeleted = false)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;

            Players = new List<FootballPlayer>();
            Leagues = new List<FootballLeague>();
        }

        public void AddPlayer(FootballPlayer player)
        {
            Players.Add(player);
        }

        public void AddLeague(FootballLeague league)
        {
            Leagues.Add(league);
        }
    }
}
