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
    public class ContractService: IContractService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ContractService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ContractDTO>> GetAllContract()
        {
            var contracts = await db.Contracts.ToListAsync();
            return _mapper.Map<IEnumerable<ContractDTO>>(contracts);
        }
        public async Task<ContractDTO> GetContractById(Guid id)
        {
            var contract = await db.Contracts.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ContractDTO>(contract);
        }
        public async Task<int> CreateContract(ContractDTO contractDTO)
        {
            var contract = _mapper.Map<Contract>(contractDTO);
            await db.Contracts.AddAsync(contract);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateContract(ContractDTO contractDTO)
        {
            var contractMapper = _mapper.Map<Contract>(contractDTO);

            var contract = await db.Contracts.FirstOrDefaultAsync(c => c.Id == contractMapper.Id);
            if (contract == null) throw new Exception("Contract not found");

            contract.Name = contractDTO.Name != null ? contractDTO.Name : contract.Name;
            contract.DateStart = contractDTO.DateStart != null ? contractDTO.DateStart : contract.DateStart;
            contract.DateEnd = contractDTO.DateEnd != null ? contractDTO.DateEnd : contract.DateEnd;
            contract.ResponsibleId = contractDTO.ResponsibleId != null ? contractDTO.ResponsibleId : contract.ResponsibleId;
            contract.OpportunityId = contractDTO.OpportunityId != null ? contractDTO.OpportunityId : contract.OpportunityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullContract(ContractDTO contractDTO)
        {
            var contractMapper = _mapper.Map<Contract>(contractDTO);

            var contract = await db.Contracts.FirstOrDefaultAsync(c => c.Id == contractMapper.Id);
            if (contract == null) throw new Exception("Contract not found");

            contract.Name = contractDTO.Name;
            contract.DateStart = contractDTO.DateStart;
            contract.DateEnd = contractDTO.DateEnd;
            contract.ResponsibleId = contractDTO.ResponsibleId;
            contract.OpportunityId = contractDTO.OpportunityId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteContract(Guid Id)
        {
            var contract = await db.Contracts.FirstOrDefaultAsync(c => c.Id == Id);
            if (contract == null) throw new Exception("Contract not found");

            db.Contracts.Remove(contract);

            return await db.SaveChangesAsync();
        }

    }
}
