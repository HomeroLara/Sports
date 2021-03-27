using System;
using System.Linq;
using System.Collections.Generic;

using Sports.Core.Models;
using Sports.Core.Models.Sports;
using Sports.Core.Models.Sports.NBA;

namespace Sports.Core
{
    public class InstanceSettings
    {
        #region PUBLIC MEMBERS
        public List<Team> NBATeams { get; set; }
        public List<Game> NBAGames { get; set; }
        #endregion


        #region PUBLIC STATIC MEMBERS
        public static InstanceSettings Session { get; } = new InstanceSettings();
        #endregion

        #region CONSTRUCTORS
        public InstanceSettings()
        {
        }
        #endregion
    }
}
