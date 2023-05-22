using Core.Domain.Entities.Shared;

namespace Core.Domain.Entities
{
    public class FootballPlayer : Entity<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int TeamId { get; private set; }
        public virtual FootballTeam Team { get; private set; }

        public FootballPlayer()
        {

        }

        public FootballPlayer(int id, string firstName, string lastName, int teamId, bool isDeleted = false)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TeamId = teamId;
            IsDeleted = isDeleted;
        }
    }
}
