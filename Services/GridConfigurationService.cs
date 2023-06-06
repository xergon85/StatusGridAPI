using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StatusGridAPI.Data;
using StatusGridAPI.DTOs;
using StatusGridAPI.Models;
using StatusGridAPI.Response;

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

        public async Task<ServiceResponse<GetGridConfigurationDTO>> GetGridConfiguration(string name)
        {
            var response = new ServiceResponse<GetGridConfigurationDTO>();
            var gridConfigurations = await _dataContext.GridConfigurations
                .Include(gc => gc.Statuses)
                .ToListAsync();
            var gridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == name);

            if (gridConfiguration == null)
            {
                response.Success = false;
                response.Message = "Grid configuration not found";
                return response;
            }
            response.Data = _mapper.Map<GetGridConfigurationDTO>(gridConfiguration);

            return response;
        }

        public async Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> GetAllConfigurations()
        {
            var response = new ServiceResponse<List<GetAllGridConfigurationsDTO>>();
            response.Data = await FetchAllConfigurations();

            return response;
        }

        public async Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> CreateConfiguration(CreateGridConfigurationDTO gridConfiguration)
        {
            var response = new ServiceResponse<List<GetAllGridConfigurationsDTO>>();

            if (gridConfiguration.Name == null || gridConfiguration.Name == "")
            {
                response = new ServiceResponse<List<GetAllGridConfigurationsDTO>>();
                response.Success = false;
                response.Message = "Name cannot be null or empty";
                return response;
            }

            var gridConfigurations = await _dataContext.GridConfigurations.ToListAsync();
            var existingGridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == gridConfiguration.Name);

            if (existingGridConfiguration != null)
            {
                _dataContext.Remove(existingGridConfiguration);
                await _dataContext.SaveChangesAsync();
            }

            var config = _mapper.Map<GridConfiguration>(gridConfiguration);
            _dataContext.Add(config);

            await _dataContext.SaveChangesAsync();

            response.Data = await FetchAllConfigurations();

            return response;
        }

        public async Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> RemoveConfiguration(string name)
        {
            var response = new ServiceResponse<List<GetAllGridConfigurationsDTO>>();
            var gridConfigurations = await _dataContext.GridConfigurations.ToListAsync();
            var existingGridConfiguration = gridConfigurations.FirstOrDefault(gc => gc.Name == name);

            if (existingGridConfiguration != null)
            {
                _dataContext.Remove(existingGridConfiguration);
                await _dataContext.SaveChangesAsync();
                response.Data = await FetchAllConfigurations();
                return response;
            }

            response.Success = false;
            response.Message = "Grid configuration not found";
            return response;
        }

        private async Task<List<GetAllGridConfigurationsDTO>> FetchAllConfigurations()
        {
            var gridConfigurations = await _dataContext.GridConfigurations
                .ToListAsync();

            return _mapper.Map<List<GetAllGridConfigurationsDTO>>(gridConfigurations);
        }
    }
}