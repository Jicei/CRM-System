using AutoMapper;
using CRM.BLL.DTO;
using CRM.DAL.Entities;

namespace CRM.BLL.MapperProfiles
{
    public class MapperConfig: Profile
    {
        public MapperConfig() {

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
        }
    }
}
