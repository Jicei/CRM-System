using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContact();
        Task<ContactDTO> GetContactById(Guid id);
        Task<int> CreateContact(ContactDTO contactDTO);
        Task<int> UpdateContact(ContactDTO contactDTO);
        Task<int> UpdateFullContact(ContactDTO contactDTO);
        Task<int> DeleteContact(Guid Id);
    }
}
