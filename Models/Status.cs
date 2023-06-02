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