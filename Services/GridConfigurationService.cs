using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StatusGridAPI.Data;
using StatusGridAPI.DTOs;
using StatusGridAPI.Models;

namespace StatusGridAPI.Services
{
    public class GridConfigurationService : IGridConfigurationService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GridConfigurationService(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<GetGridConfigurationDTO> GetGridConfiguration(string name)
        {
            var gridConfigurations = await _dataContext.GridConfigurations
                .Include(gc => gc.Statuses)
                .ToListAsync();
            var gridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == name);

            if (gridConfiguration == null)
            {
                throw new Exception("Grid configuration not found");
            }

            var grid = _mapper.Map<GetGridConfigurationDTO>(gridConfiguration);

            return grid;
        }

        public async Task<List<GetAllGridConfigurationsDTO>> GetAllConfigurations()
        {
            var gridConfigurations = await _dataContext.GridConfigurations
                .ToListAsync();

            var gridConfigurationsDTO = _mapper.Map<List<GetAllGridConfigurationsDTO>>(gridConfigurations);

            // Create a response and return that?
            return gridConfigurationsDTO;

        }

        public async void CreateConfiguration(CreateGridConfigurationDTO gridConfiguration)
        {
            var gridConfigurations = await _dataContext.GridConfigurations.ToListAsync();
            var existingGridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == gridConfiguration.Name);

            if (existingGridConfiguration != null)
            {
                _dataContext.Remove(existingGridConfiguration);
            }

            var config = _mapper.Map<GridConfiguration>(gridConfiguration);
            _dataContext.Add(config);

            await _dataContext.SaveChangesAsync();
        }

        public async void RemoveConfiguration(string name)
        {
            var gridConfigurations = await _dataContext.GridConfigurations.ToListAsync();
            var existingGridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == name);

            if (existingGridConfiguration != null)
            {
                _dataContext.Remove(existingGridConfiguration);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}