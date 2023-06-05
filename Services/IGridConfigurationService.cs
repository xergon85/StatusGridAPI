using StatusGridAPI.DTOs;
using StatusGridAPI.Response;

namespace StatusGridAPI.Services
{
    public interface IGridConfigurationService
    {
        Task<ServiceResponse<GetGridConfigurationDTO>> GetGridConfiguration(string name);
        Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> GetAllConfigurations();
        Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> CreateConfiguration(CreateGridConfigurationDTO gridConfiguration);
        Task<ServiceResponse<List<GetAllGridConfigurationsDTO>>> RemoveConfiguration(string name);
    }
}