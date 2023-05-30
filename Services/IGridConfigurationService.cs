using StatusGridAPI.DTOs;
using StatusGridAPI.Models;

namespace StatusGridAPI.Services
{
    public interface IGridConfigurationService
    {
        Task<GridConfiguration> GetGridConfiguration(string name);
        Task<List<GridConfiguration>> GetAllConfigurations();
        void SaveConfiguration(AddGridConfigurationDTO gridConfiguration);
        void RemoveConfiguration(GridConfiguration gridConfiguration);
    }
}