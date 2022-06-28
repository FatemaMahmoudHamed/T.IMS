using IMS.Core.Dtos;
using IMS.Core.Models;
using System.Threading.Tasks;

namespace IMS.Core.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ReturnResult<CustomerDto>> GetAsync(int id);

        Task<ReturnResult<CustomerDto>> AddAsync(CustomerDto customerDto);


    }

}
