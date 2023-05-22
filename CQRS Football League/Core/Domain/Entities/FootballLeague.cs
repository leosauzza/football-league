using Core.Domain.Entities.Shared;

namespace Core.Domain.Entities
{
    public class FootballLeague : Entity<int>
    {
        public string Name { get; private set; }
        public virtual ICollection<FootballTeam> Teams { get; private set; }

        public FootballLeague()
        {

        }

        public FootballLeague(int id, string name, bool isDeleted=false)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;

            Teams = new List<FootballTeam>();
        }

        public void AddFootballTeam(FootballTeam team) 
        { 
            Teams.Add(team); 
        }
    }
}
