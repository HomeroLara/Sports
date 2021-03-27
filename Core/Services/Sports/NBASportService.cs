using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sports.Core.Models.Sports;
using Sports.Core.Models.Sports.NBA;
using Flurl.Http;

namespace Sports.Core.Services
{
    public class NBASportService : INBASportService
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PUBLIC MEMBERS
        #endregion

        #region CONSTRUCTORS
        public NBASportService()
        {
        }
        #endregion

        #region IMPLEMENTATION
        public Task<GetAllTeamsPayload> GetTeams()
        {
            var endPoint = $"http://data.nba.net/prod/v2/2020/teams.json";

            var payload = endPoint
                .GetJsonAsync<GetAllTeamsPayload>();

            return payload;
        }

        public Task<List<Sport>> GetSports()
        {
            var sports = new List<Sport> {
                new Sport(){
                    Name = "National Football League",
                    SportType = SportType.NFL,
                    LogoUri = "nfl_logo",
                    },

                new Sport(){
                    Name = "National Basketball Association",
                    SportType = SportType.NBA,
                    LogoUri = "nba_logo",
                },

                new Sport(){
                    Name = "Ultimate Fighting Championshio",
                    SportType = SportType.MMA,
                    LogoUri = "ufc_logo",
                },

                new Sport()
                {
                    Name = "National Hockey League",
                    SportType = SportType.NHL,
                    LogoUri = "nhl_logo",
                },

                new Sport()
                {
                    Name = "Major League Baseball",
                    SportType = SportType.MLB,
                    LogoUri = "mlb_logo",
                },
            };

            return Task.Run(() => {
                return sports;
            });
        }

        public async Task<GetGamesByDatePayload> GetNBAGamesByDate(DateTime date)
        {
            var formattedDate = date.ToString("yyyyMMdd");
            var endPoint = $"http://data.nba.net/prod/v1/{formattedDate}/scoreboard.json";

            var payload = await endPoint
                .GetJsonAsync<GetGamesByDatePayload>();

            return payload;
        }
        #endregion
    }
}
