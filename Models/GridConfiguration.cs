using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StatusGridAPI.Models
{
    public class GridConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Status> Statuses { get; set; }
    }
}