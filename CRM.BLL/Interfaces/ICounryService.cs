using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDTO>> GetAllCountry();
        Task<CountryDTO> GetCountryById(Guid id);
        Task<int> CreateCountry(CountryDTO countryDTO);
        Task<int> UpdateCountry(CountryDTO countryDTO);
        Task<int> UpdateFullCountry(CountryDTO countryDTO);
        Task<int> DeleteCountry(Guid Id);
    }
}
