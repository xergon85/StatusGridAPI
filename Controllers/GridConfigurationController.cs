using Microsoft.AspNetCore.Mvc;
using StatusGridAPI.DTOs;
using StatusGridAPI.Response;
using StatusGridAPI.Services;

namespace StatusGridAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GridConfigurationController : ControllerBase
    {
        private readonly IGridConfigurationService _gridConfigurationService;

        public GridConfigurationController(IGridConfigurationService gridConfigurationService)
        {
            _gridConfigurationService = gridConfigurationService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetAllGridConfigurationsDTO>>>> GetGridConfigurations()
        {
            var response = await _gridConfigurationService.GetAllConfigurations();
            return Ok(response);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<GetGridConfigurationDTO>>> GetGridConfiguration(string name)
        {
            var response = await _gridConfigurationService.GetGridConfiguration(name);
            if (response.Success == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetAllGridConfigurationsDTO>>>> CreateGridConfiguration(CreateGridConfigurationDTO gridConfiguration)
        {
            var response = await _gridConfigurationService.CreateConfiguration(gridConfiguration);

            if (response.Success == false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<ServiceResponse<List<GetAllGridConfigurationsDTO>>>> DeleteGridConfiguration(string name)
        {

            var response = await _gridConfigurationService.RemoveConfiguration(name);
            if (response.Success == false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}