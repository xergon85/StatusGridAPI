using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace StatusGridAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode statusCode { get; set; }
        public int GridConfigurationId { get; set; }

    }
}