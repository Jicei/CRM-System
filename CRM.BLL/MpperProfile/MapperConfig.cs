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

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>();

            CreateMap<ActivityManager, ActivityManagerDTO>();
            CreateMap<ActivityManagerDTO, ActivityManager>();

            CreateMap<ActivityManagerType, ActivityManagerTypeDTO>();
            CreateMap<ActivityManagerTypeDTO, ActivityManagerType>();

            CreateMap<ActivityType, ActivityTypeDTO>();
            CreateMap<ActivityTypeDTO, ActivityType>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<Contract, ContractDTO>();
            CreateMap<ContractDTO, Contract>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<EmployeeInRole, EmployeeInRoleDTO>();
            CreateMap<EmployeeInRoleDTO, EmployeeInRole>();
        }
    }
}
