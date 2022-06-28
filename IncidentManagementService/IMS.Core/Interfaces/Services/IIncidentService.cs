using IMS.Core.Dtos;
using IMS.Core.Models;
using IMS.Infrastructure.Entities;
using System.Threading.Tasks;

namespace IMS.Core.Interfaces.Services
{
    public interface IIncidentService
    {
        Task<ReturnResult<IncidentDto>> GetAsync(int id);
        Task<ReturnResult<QueryResultDto<IncidentDto>>> GetAllAsync(IncidentQueryObject queryObject);
        Task<ReturnResult<IncidentDto>> AddAsync(IncidentDto incident);

    }

}
