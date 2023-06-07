namespace StatusGridAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public StatusCode StatusCode { get; set; }
        public int GridConfigurationId { get; set; }

    }
}