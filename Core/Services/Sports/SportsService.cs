using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sports.Core.Models.Sports;

namespace Sports.Core.Services
{
    public class SportsService: ISportsService
    {
        #region PRIVATE MEMBERS
        #endregion

        #region PUBLIC MEMBERS
        #endregion

        #region CONSTRUCTORS
        public SportsService()
        {
        }
        #endregion

        #region IMPLEMENTATION
        public Task<List<Sport>> GetSports()
        {
            var sports = new List<Sport> {
                    new Sport(){
                        Name = "National Football League",
                        SportType = SportType.NFL,
                        LogoUri = "nfl_logo"
                     },

                    new Sport(){
                        Name = "National Basketball Association",
                        SportType = SportType.NBA,
                        LogoUri = "nba_logo"
                    },

                    new Sport(){
                        Name = "Ultimate Fighting Championshio",
                        SportType = SportType.MMA,
                        LogoUri = "ufc_logo"
                    }
            };

            return Task.Run(() => {
                return sports;
            });
        }
        #endregion
    }
}
