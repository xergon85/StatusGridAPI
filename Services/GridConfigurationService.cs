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

        public async Task<GridConfiguration> GetGridConfiguration(string name)
        {
            var gridConfigurations = await _dataContext.GridConfigurations
                .Include(gc => gc.Statuses)
                .ToListAsync();
            var gridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == name);

            return gridConfiguration;
        }

        public async Task<List<GridConfiguration>> GetAllConfigurations()
        {
            var gridConfigurations = await _dataContext.GridConfigurations
                .ToListAsync();

            // Create a response and return that?
            return gridConfigurations;

        }

        public async void SaveConfiguration(AddGridConfigurationDTO gridConfiguration)
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

        public async void RemoveConfiguration(GridConfiguration gridConfiguration)
        {
            var gridConfigurations = await _dataContext.GridConfigurations.ToListAsync();
            var existingGridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == gridConfiguration.Name);

            if (existingGridConfiguration != null)
            {
                _dataContext.Remove(existingGridConfiguration);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}