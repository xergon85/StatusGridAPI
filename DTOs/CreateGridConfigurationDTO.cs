namespace StatusGridAPI.DTOs
{
    public class CreateGridConfigurationDTO
    {
        public string Name { get; set; } = "";
        public ICollection<CreateStatusDTO> Statuses { get; set; }
    }
}