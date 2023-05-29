using StatusGridAPI.Models;

namespace StatusGridAPI.Services
{
    public interface IGridConfigurationService
    {
        GridConfiguration? GetGridConfiguration(string name);
        List<GridConfiguration> GetAllConfigurations();
        void SaveConfiguration(GridConfiguration gridConfiguration);
        void RemoveConfiguration(GridConfiguration gridConfiguration);
    }
}