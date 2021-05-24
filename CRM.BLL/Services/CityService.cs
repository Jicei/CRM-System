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
    public class CityService: ICityService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public CityService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CityDTO>> GetAllCity()
        {
            var cities = await db.Cities.ToListAsync();
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }
        public async Task<CityDTO> GetCityById(Guid id)
        {
            var city = await db.Cities.FirstOrDefaultAsync(city => city.Id == id);
            return _mapper.Map<CityDTO>(city);
        }
        public async Task<int> CreateCity(CityDTO cityDTO)
        {
            var city = _mapper.Map<City>(cityDTO);
            await db.Cities.AddAsync(city);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateCity(CityDTO cityDTO)
        {
            var cityMapper = _mapper.Map<City>(cityDTO);

            var city = await db.Cities.FirstOrDefaultAsync(c => c.Id == cityMapper.Id);
            if (city == null) throw new Exception("City not found");

            city.Name = cityDTO.Name != null ? cityDTO.Name : city.Name;
            city.CountryId = cityDTO.CountryId != null ? cityDTO.CountryId : city.CountryId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullCity(CityDTO cityDTO)
        {
            var cityMapper = _mapper.Map<City>(cityDTO);

            var city = await db.Cities.FirstOrDefaultAsync(c => c.Id == cityMapper.Id);
            if (city == null) throw new Exception("City not found");

            city.Name = cityDTO.Name;
            city.CountryId = cityDTO.CountryId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteCity(Guid Id)
        {
            var city = await db.Cities.FirstOrDefaultAsync(c => c.Id == Id);
            if (city == null) throw new Exception("City not found");

            db.Cities.Remove(city);

            return await db.SaveChangesAsync();
        }

    }
}
