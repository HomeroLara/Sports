using System;
namespace Sports.Core.Models.Sports.NBA
{
    public class GameTeamDTO
    {
        public Game Game { get; set; }
        public Team HomeTeam { get; set; }
        public Team VisitingTeam { get; set; }

        public GameTeamDTO()
        {
        }
    }
}
