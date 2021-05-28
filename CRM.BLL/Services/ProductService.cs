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
    public class ProductService: IProductService
    {
        private readonly CrmDbContext db;
        private readonly IMapper _mapper;
        public ProductService(CrmDbContext _crmDbContext, IMapper mapper)
        {
            db = _crmDbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            var products = await db.Products.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var product = await db.Products.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<int> CreateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await db.Products.AddAsync(product);

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateProduct(ProductDTO productDTO)
        {
            var productMapper = _mapper.Map<Product>(productDTO);

            var product = await db.Products.FirstOrDefaultAsync(c => c.Id == productMapper.Id);
            if (product == null) throw new Exception("Product not found");

            product.Name = productDTO.Name != null ? productDTO.Name : product.Name;
            product.Price = productDTO.Price != 0 ? productDTO.Price : 0;
            product.Description = productDTO.Description != null ? productDTO.Description : product.Description;
            product.Remains = productDTO.Remains != 0 ? productDTO.Remains : 0;
            product.ResponsibleId = productDTO.ResponsibleId != null ? productDTO.ResponsibleId : product.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> UpdateFullProduct(ProductDTO productDTO)
        {
            var productMapper = _mapper.Map<Product>(productDTO);

            var product = await db.Products.FirstOrDefaultAsync(c => c.Id == productMapper.Id);
            if (product == null) throw new Exception("Product not found");

            product.Name = productDTO.Name;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;
            product.Remains = productDTO.Remains;
            product.ResponsibleId = productDTO.ResponsibleId;

            return await db.SaveChangesAsync();
        }
        public async Task<int> DeleteProduct(Guid Id)
        {
            var product = await db.Products.FirstOrDefaultAsync(c => c.Id == Id);
            if (product == null) throw new Exception("Product not found");

            db.Products.Remove(product);

            return await db.SaveChangesAsync();
        }
        public IQueryable<ProductABCFMRAnalysisDTO> ProductABCanalysis(DateTime dateFrom, DateTime dateTo)
        {
            var opportunityTotalSum = db.Opportunities.Where(o => o.DateEnd >= dateFrom && o.DateEnd <= dateTo).Sum(o => o.Price);

            var totalQuantity = (from o in db.Opportunities
                                 join po in db.ProductInOpportunities on o.Id equals po.ProductId
                                 where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
                                 select new { po.Id }).Count();

            var productsPartAmount = from o in db.Opportunities
                                     join po in db.ProductInOpportunities on o.Id equals po.ProductId
                                     join p in db.Products on po.ProductId equals p.Id
                                     where o.DateEnd >= dateFrom && o.DateEnd <= dateTo
                                     group p by new { p.Id, p.Name } into productGroup
                                     orderby productGroup.Sum(p => p.Price) descending
                                     select new ProductABCFMRAnalysisDTO
                                     {
                                         ProductId = productGroup.Key.Id,
                                         ProductName = productGroup.Key.Name,
                                         Amount = productGroup.Sum(p => p.Price),
                                         Quantity = (from o in db.Opportunities
                                                     join po in db.ProductInOpportunities on o.Id equals po.ProductId
                                                     where o.DateEnd >= dateFrom && o.DateEnd <= dateTo && po.ProductId == productGroup.Key.Id
                                                     select new { po.Id }).Count()
                                     };
            float partAmount = 0;
            float partQuantity = 0;
            foreach (var pr in productsPartAmount)
            {
                if (partAmount <= 0.8)
                {
                    pr.Category = "A";
                }
                else if (partAmount <= 0.95)
                {
                    pr.Category = "B";
                }
                else
                {
                    pr.Category = "C";
                }
                pr.PartAmount = pr.Amount / opportunityTotalSum;
                partAmount += pr.PartAmount;
                if (partAmount <= 0.8)
                {
                    pr.Category = string.Concat(pr.Category, "X");
                }
                else if (partAmount <= 0.95)
                {
                    pr.Category = string.Concat(pr.Category, "Y");
                }
                else
                {
                    pr.Category = string.Concat(pr.Category, "Z");
                }
                pr.PartQuantity = pr.Quantity / totalQuantity;
                partQuantity += pr.PartQuantity;
            }

            return productsPartAmount;
        }
    }
}
