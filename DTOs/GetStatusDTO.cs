using StatusGridAPI.Models;

namespace StatusGridAPI.DTOs
{
    public class GetStatusDTO
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode statusCode { get; set; }
    }
}