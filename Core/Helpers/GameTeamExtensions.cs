using System;
using System.Linq;
using System.Collections.Generic;
using Sports.Core;
using Sports.Core.Models.Sports.NBA;

namespace Sports.Core.Helpers
{
    public static class GameExtensions
    {
        public static List<GameTeamDTO> GetGameTeamDTOs(this GetGamesByDatePayload getGamesByDatePayload, List<Team> teams)
        {
            //TODO: refactor this code

            var game_teamDTOs = new List<GameTeamDTO>(getGamesByDatePayload.Games.Count);
            GameTeamDTO game_teamDTO;
            Team homeTeam;
            Team visitingTeam;
            getGamesByDatePayload.Games.ForEach(game => {
                homeTeam = teams.FirstOrDefault(h => h.TeamId == game.HTeam.TeamId);
                homeTeam.Win = game.HTeam.Win;
                homeTeam.Loss = game.HTeam.Loss;

                visitingTeam = teams.FirstOrDefault(v => v.TeamId == game.VTeam.TeamId);
                visitingTeam.Win = game.VTeam.Win;
                visitingTeam.Loss = game.VTeam.Loss;

                if (homeTeam != null && visitingTeam != null)
                {
                    game_teamDTO = new GameTeamDTO()
                    {
                        HomeTeam = homeTeam,
                        VisitingTeam = visitingTeam,
                        Game = game,
                    };
                    game_teamDTOs.Add(game_teamDTO);
                }
            });

            return game_teamDTOs;
        }
    }
}
