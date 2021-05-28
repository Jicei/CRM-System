using AutoMapper;
using CRM.BLL.DTO;
using CRM.BLL.Interfaces;
using CRM.DAL;
using CRM.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.BLL.Services
{
    public class ContactService: IContactService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ContactService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ContactDTO>> GetAllContact()
        {
            var contacts = await db.Contacts.ToListAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
        }
        public async Task<ContactDTO> GetContactById(Guid id)
        {
            var contact = await db.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ContactDTO>(contact);
        }
        public async Task<int> CreateContact(ContactDTO contactDTO)
        {
            var contact = _mapper.Map<Contact>(contactDTO);
            await db.Contacts.AddAsync(contact);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateContact(ContactDTO contactDTO)
        {
            var contactMapper = _mapper.Map<Contact>(contactDTO);

            var contact = await db.Contacts.FirstOrDefaultAsync(c => c.Id == contactMapper.Id);
            if (contact == null) throw new Exception("Contact not found");

            contact.Name = contactDTO.Name != null ? contactDTO.Name : contact.Name;
            contact.Surname = contactDTO.Surname != null ? contactDTO.Surname : contact.Surname;
            contact.Patronymic = contactDTO.Patronymic != null ? contactDTO.Patronymic : contact.Patronymic;
            contact.Telephone = contactDTO.Telephone != null ? contactDTO.Telephone : contact.Telephone;
            contact.Desctiption = contactDTO.Description != null ? contactDTO.Description : contact.Desctiption;
            contact.CompanyId = contactDTO.CompanyId != null ? contactDTO.CompanyId : contact.CompanyId;
            contact.CountryId = contactDTO.CountryId != null ? contactDTO.CountryId : contact.CountryId;
            contact.ResponsibleId = contactDTO.ResponsibleId != null ? contactDTO.ResponsibleId : contact.ResponsibleId;
            contact.CityId = contactDTO.CityId != null ? contactDTO.CityId : contact.CityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullContact(ContactDTO contactDTO)
        {
            var contactMapper = _mapper.Map<Contact>(contactDTO);

            var contact = await db.Contacts.FirstOrDefaultAsync(c => c.Id == contactMapper.Id);
            if (contact == null) throw new Exception("Contact not found");

            contact.Name = contactDTO.Name;
            contact.Surname = contactDTO.Surname;
            contact.Patronymic = contactDTO.Patronymic;
            contact.Telephone = contactDTO.Telephone;
            contact.Desctiption = contactDTO.Description;
            contact.CompanyId = contactDTO.CompanyId;
            contact.CountryId = contactDTO.CountryId;
            contact.ResponsibleId = contactDTO.ResponsibleId;
            contact.CityId = contactDTO.CityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteContact(Guid Id)
        {
            var contact = await db.Contacts.FirstOrDefaultAsync(c => c.Id == Id);
            if (contact == null) throw new Exception("Contact not found");

            db.Contacts.Remove(contact);

            return await db.SaveChangesAsync();
        }
    }
}
