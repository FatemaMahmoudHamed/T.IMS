using IMS.Core.Dtos;
using System.Threading.Tasks;

namespace IMS.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetAsync(int Id);
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerDto> GetByEmailAsync(string email);
    }
}