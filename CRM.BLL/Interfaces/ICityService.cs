using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> GetAllCity();
        Task<CityDTO> GetCityById(Guid id);
        Task<int> CreateCity(CityDTO cityDTO);
        Task<int> UpdateCity(CityDTO cityDTO);
        Task<int> UpdateFullCity(CityDTO cityDTO);
        Task<int> DeleteCity(Guid Id);
    }
}
