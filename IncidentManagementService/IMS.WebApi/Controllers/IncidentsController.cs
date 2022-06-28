using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IMS.Core.Dtos;
using IMS.Core.Interfaces.Services;
using IMS.Infrastructure.Entities;
using System.Threading.Tasks;

namespace IMS.WebApi.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _incidentService.GetAsync(id);
            return StatusCode((int)result.StatusCode, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(IncidentQueryObject queryObject)
        {
            var result = await _incidentService.GetAllAsync(queryObject);
            return StatusCode((int)result.StatusCode, result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IncidentDto incidentDto)
        {
            var result = await _incidentService.AddAsync(incidentDto);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}