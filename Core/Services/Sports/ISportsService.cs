using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sports.Core.Models.Sports;
using Sports.Core.Models.Sports.NBA;

namespace Sports.Core.Services
{
    public interface ISportsService
    {
        Task<List<Sport>> GetSports();
        Task<GetGamesByDatePayload> GetNBAGamesByDate(DateTime date); 
    }
}
