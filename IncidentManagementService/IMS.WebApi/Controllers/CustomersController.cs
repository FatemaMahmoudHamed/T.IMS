using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMS.Core.Dtos;
using IMS.Core.Interfaces.Services;
using IMS.Infrastructure.Entities;
using System.Threading.Tasks;

namespace IMS.WebApi.Controllers
{
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _customerService.GetAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CustomerDto customerDto)
        {
            var result = await _customerService.AddAsync(customerDto);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}