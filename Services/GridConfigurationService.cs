using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusGridAPI.Models;

namespace StatusGridAPI.Services
{
    public class GridConfigurationService : IGridConfigurationService
    {
        private static List<GridConfiguration> _gridConfigurations = new List<GridConfiguration> {
            new GridConfiguration {
                Name = "Default",
                Id = 1,
                Statuses = new List<Status> {
                    new Status { Id = 1, X = 0, Y = 0, statusCode = StatusCode.Untouched, GridConfigurationId = 1 },
                    new Status { Id = 2, X = 0, Y = 1, statusCode = StatusCode.Untouched, GridConfigurationId = 1 },
                    new Status { Id = 3, X = 1, Y = 0, statusCode = StatusCode.Untouched, GridConfigurationId = 1 },
                    new Status { Id = 4, X = 1, Y = 1, statusCode = StatusCode.Untouched, GridConfigurationId = 1 }
                }
            }
        };



        // public GridConfigurationService()
        // {

        //     var gridConfig = new GridConfiguration { Name = "Default", Id = 1 };
        //     var statuses = new List<Status>();
        //     statuses.Add(new Status { Id = 1, X = 0, Y = 0, statusCode = StatusCode.Untouched, GridConfigurationId = 1 });
        //     statuses.Add(new Status { Id = 2, X = 0, Y = 1, statusCode = StatusCode.Untouched, GridConfigurationId = 1 });
        //     statuses.Add(new Status { Id = 3, X = 1, Y = 0, statusCode = StatusCode.Untouched, GridConfigurationId = 1 });
        //     statuses.Add(new Status { Id = 4, X = 1, Y = 1, statusCode = StatusCode.Untouched, GridConfigurationId = 1 });
        //     gridConfig.Statuses = statuses;

        //     _gridConfigurations.Add(gridConfig);
        // }


        public GridConfiguration? GetGridConfiguration(string name)
        {
            return _gridConfigurations.FirstOrDefault(gc => gc.Name == name);
        }

        public List<GridConfiguration> GetAllConfigurations()
        {
            return _gridConfigurations;
        }

        public void SaveConfiguration(GridConfiguration gridConfiguration)
        {
            var existingGridConfiguration = _gridConfigurations.FirstOrDefault(gc => gc.Name == gridConfiguration.Name);
            if (existingGridConfiguration != null)
            {
                _gridConfigurations.Remove(existingGridConfiguration);
            }
            _gridConfigurations.Add(gridConfiguration);
        }

        public void RemoveConfiguration(GridConfiguration gridConfiguration)
        {
            var existing = _gridConfigurations.FirstOrDefault(gc => gc.Name == gridConfiguration.Name);
            if (existing != null)
            {
                _gridConfigurations.Remove(existing);
            }
        }
    }
}