using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatusGridAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode statusCode { get; set; }
        public int GridConfigurationId { get; set; }
        public GridConfiguration GridConfiguration { get; set; }
    }
}