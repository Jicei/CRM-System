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
    public class CompanyService : ICompanyService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public CompanyService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDTO>> GetAllCompany()
        {
            var company = await db.Companies.ToListAsync();
            return _mapper.Map<IEnumerable<CompanyDTO>>(company);
        }
        public async Task<CompanyDTO> GetCompanyById(Guid id)
        {
            var company = await db.Companies.FirstOrDefaultAsync(a => a.Id == id);
            return _mapper.Map<CompanyDTO>(company);
        }
        public async Task<int> CreateCompany(CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            await db.Companies.AddAsync(company);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateCompany(CompanyDTO companyDTO)
        {
            var companyMapper = _mapper.Map<Activity>(companyDTO);

            var company = await db.Companies.FirstOrDefaultAsync(c => c.Id == companyMapper.Id);
            if (company == null) throw new Exception("Company not found");

            company.Name = companyDTO.Name != null ? companyDTO.Name : company.Name;
            company.Telephone = companyDTO.Telephone != null ? companyDTO.Telephone : company.Telephone;
            company.Email = companyDTO.Email != null ? companyDTO.Email : company.Email;
            company.ResponsibleId = companyDTO.ResponsibleId != null ? companyDTO.ResponsibleId : company.ResponsibleId;
            company.CountryId = companyDTO.CountryId != null ? companyDTO.CountryId : company.CountryId;
            company.CityId = companyDTO.CityId != null ? companyDTO.CityId : company.CityId;
            company.LeadId = companyDTO.LeadId != null ? companyDTO.LeadId : company.LeadId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullCompany(CompanyDTO companyDTO)
        {
            var companyMapper = _mapper.Map<Company>(companyDTO);

            var company = await db.Companies.FirstOrDefaultAsync(c => c.Id == companyMapper.Id);
            if (company == null) throw new Exception("Activity not found");

            company.Name = companyDTO.Name;
            company.Telephone = companyDTO.Telephone;
            company.Email = companyDTO.Email;
            company.ResponsibleId = companyDTO.ResponsibleId;
            company.CountryId = companyDTO.CountryId;
            company.CityId = companyDTO.CityId;
            company.LeadId = companyDTO.LeadId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteCompany(Guid Id)
        {
            var company = await db.Companies.FirstOrDefaultAsync(c => c.Id == Id);
            if (company == null) throw new Exception("Company not found");

            db.Companies.Remove(company);

            return await db.SaveChangesAsync();
        }
    }
}
