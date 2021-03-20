using System.Collections.Generic;
using System.Threading.Tasks;
using Sports.Core.Models.Sports;

namespace Sports.Core.Services
{
    public interface ISportsService
    {
        Task<List<Sport>> GetSports();
    }
}
