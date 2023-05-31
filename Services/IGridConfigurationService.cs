using StatusGridAPI.DTOs;
using StatusGridAPI.Models;

namespace StatusGridAPI.Services
{
    public interface IGridConfigurationService
    {
        Task<GetGridConfigurationDTO> GetGridConfiguration(string name);
        Task<List<GetAllGridConfigurationsDTO>> GetAllConfigurations();
        void CreateConfiguration(CreateGridConfigurationDTO gridConfiguration);
        void RemoveConfiguration(string name);
    }
}