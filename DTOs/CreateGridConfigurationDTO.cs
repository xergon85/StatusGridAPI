using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusGridAPI.Models;

namespace StatusGridAPI.DTOs
{
    public class CreateGridConfigurationDTO
    {
        public string Name { get; set; } = "";
        public ICollection<CreateStatusDTO> Statuses { get; set; }
    }
}