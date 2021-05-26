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
    public class ProductInOpportunityService : IProductInOpportunityService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ProductInOpportunityService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductInOpportunityDTO>> GetAllProductInOpportunity()
        {
            var productInOpportunities = await db.ProductInOpportunities.ToListAsync();
            return _mapper.Map<IEnumerable<ProductInOpportunityDTO>>(productInOpportunities);
        }
        public async Task<ProductInOpportunityDTO> GetProductInOpportunityById(Guid id)
        {
            var productInOpportunity = await db.ProductInOpportunities.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ProductInOpportunityDTO>(productInOpportunity);
        }
        public async Task<int> CreateProductInOpportunity(ProductInOpportunityDTO productInOpportunityDTO)
        {
            var productInOpportunity = _mapper.Map<ProductInOpportunity>(productInOpportunityDTO);
            await db.ProductInOpportunities.AddAsync(productInOpportunity);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateProductInOpportunity(ProductInOpportunityDTO productInOpportunityDTO)
        {
            var productInOpportunityMapper = _mapper.Map<ProductInOpportunity>(productInOpportunityDTO);

            var productInOpportunity = await db.ProductInOpportunities.FirstOrDefaultAsync(c => c.Id == productInOpportunityMapper.Id);
            if (productInOpportunity == null) throw new Exception("Product In Opportunity not found");

            productInOpportunity.OpportunityId = productInOpportunityDTO.OpportunityId != null ? productInOpportunityDTO.OpportunityId : productInOpportunity.OpportunityId;
            productInOpportunity.ProductId = productInOpportunityDTO.ProductId != null ? productInOpportunityDTO.ProductId : productInOpportunity.ProductId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullProductInOpportunity(ProductInOpportunityDTO productInOpportunityDTO)
        {
            var productInOpportunityMapper = _mapper.Map<Product>(productInOpportunityDTO);

            var productInOpportunity = await db.ProductInOpportunities.FirstOrDefaultAsync(c => c.Id == productInOpportunityMapper.Id);
            if (productInOpportunity == null) throw new Exception("Product In Opportunity not found");

            productInOpportunity.OpportunityId = productInOpportunityDTO.OpportunityId;
            productInOpportunity.ProductId = productInOpportunityDTO.ProductId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteProductInOpportunity(Guid Id)
        {
            var productInOpportunity = await db.ProductInOpportunities.FirstOrDefaultAsync(c => c.Id == Id);
            if (productInOpportunity == null) throw new Exception("Product In Opportunity not found");

            db.ProductInOpportunities.Remove(productInOpportunity);

            return await db.SaveChangesAsync();
        }

    }
}
