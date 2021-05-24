using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class CountryService: ICountryService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public CountryService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CountryDTO>> GetAllCountry()
        {
            var country = await db.Countries.ToListAsync();
            return _mapper.Map<IEnumerable<CountryDTO>>(country);
        }
        public async Task<CountryDTO> GetCountryById(Guid id)
        {
            var country = await db.Countries.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CountryDTO>(country);
        }
        public async Task<int> CreateCountry(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await db.Countries.AddAsync(country);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateCountry(CountryDTO countryDTO)
        {
            var countryMapper = _mapper.Map<Country>(countryDTO);

            var country = await db.Countries.FirstOrDefaultAsync(c => c.Id == countryMapper.Id);
            if (country == null) throw new Exception("Country not found");

            country.Name = countryDTO.Name != null ? countryDTO.Name : country.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullCountry(CountryDTO countryDTO)
        {
            var countryMapper = _mapper.Map<Country>(countryDTO);

            var country = await db.Countries.FirstOrDefaultAsync(c => c.Id == countryMapper.Id);
            if (country == null) throw new Exception("Country not found");

            country.Name = countryDTO.Name;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteCountry(Guid Id)
        {
            var country = await db.Countries.FirstOrDefaultAsync(c => c.Id == Id);
            if (country == null) throw new Exception("Country not found");

            db.Countries.Remove(country);

            return await db.SaveChangesAsync();
        }

    }
}
