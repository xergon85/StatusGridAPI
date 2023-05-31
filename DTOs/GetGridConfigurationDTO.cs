using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusGridAPI.Models;

namespace StatusGridAPI.DTOs
{
    public class GetGridConfigurationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<GetStatusDTO> Statuses { get; set; }
    }
}