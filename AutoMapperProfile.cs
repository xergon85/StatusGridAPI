using AutoMapper;
using StatusGridAPI.DTOs;
using StatusGridAPI.Models;

namespace StatusGridAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<GridConfiguration, GetAllGridConfigurationsDTO>();
            CreateMap<GridConfiguration, GetGridConfigurationDTO>();
            CreateMap<CreateGridConfigurationDTO, GridConfiguration>();
            CreateMap<CreateStatusDTO, Status>();
            CreateMap<Status, CreateStatusDTO>();
            CreateMap<Status, GetStatusDTO>();
        }
    }
}