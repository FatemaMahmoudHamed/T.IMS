using IMS.Core.Dtos;
using IMS.Infrastructure.Entities;
using System.Threading.Tasks;

namespace IMS.Core.Interfaces.Repositories
{
    public interface IIncidentRepository
    {
        Task<IncidentDto> GetAsync(int Id);
        Task<QueryResultDto<IncidentDto>> GetAllAsync(IncidentQueryObject queryObject);
        Task AddAsync(IncidentDto incident);

    }
}