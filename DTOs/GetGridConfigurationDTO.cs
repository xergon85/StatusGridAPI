namespace StatusGridAPI.DTOs
{
    public class GetGridConfigurationDTO
    {
        public string Name { get; set; } = "";
        public ICollection<GetStatusDTO> Statuses { get; set; }
    }
}