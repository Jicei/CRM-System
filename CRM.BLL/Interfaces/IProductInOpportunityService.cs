using CRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IProductInOpportunityService
    {
        Task<IEnumerable<ProductInOpportunityDTO>> GetAllProductInOpportunity();
        Task<ProductInOpportunityDTO> GetProductInOpportunityById(Guid id);
        Task<int> CreateProductInOpportunity(ProductInOpportunityDTO productDTO);
        Task<int> UpdateProductInOpportunity(ProductInOpportunityDTO productDTO);
        Task<int> UpdateFullProductInOpportunity(ProductInOpportunityDTO productDTO);
        Task<int> DeleteProductInOpportunity(Guid Id);
    }
}
