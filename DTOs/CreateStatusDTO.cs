using StatusGridAPI.Models;

namespace StatusGridAPI.DTOs
{
    public class CreateStatusDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode StatusCode { get; set; }
    }
}