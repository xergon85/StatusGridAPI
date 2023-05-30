using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StatusGridAPI.DTOs;
using StatusGridAPI.Models;
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
        public IActionResult GetGridConfigurations()
        {
            return Ok(_gridConfigurationService.GetAllConfigurations());
        }

        [HttpGet("{name}")]
        public IActionResult GetGridConfiguration(string name)
        {
            var gridConfiguration = _gridConfigurationService.GetGridConfiguration(name);
            if (gridConfiguration == null)
            {
                return NotFound();
            }
            return Ok(gridConfiguration);
        }

        [HttpPost]
        public IActionResult SaveGridConfiguration(AddGridConfigurationDTO gridConfiguration)
        {
            _gridConfigurationService.SaveConfiguration(gridConfiguration);
            return Ok(gridConfiguration);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteGridConfiguration(string name)
        {
            var gridConfiguration = await _gridConfigurationService.GetGridConfiguration(name);
            if (gridConfiguration == null)
            {
                return NotFound();
            }
            _gridConfigurationService.RemoveConfiguration(gridConfiguration);
            return Ok();
        }

    }
}