namespace StatusGridAPI.Models
{
    public class GridConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<Status> Statuses { get; set; }
    }
}