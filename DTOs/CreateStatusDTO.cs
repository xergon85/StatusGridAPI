using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusGridAPI.Models;

namespace StatusGridAPI.DTOs
{
    public class CreateStatusDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode statusCode { get; set; }
    }
}