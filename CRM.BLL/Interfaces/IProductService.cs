using CRM.BLL.DTO;
using CRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProduct();
        Task<ProductDTO> GetProductById(Guid id);
        Task<int> CreateProduct(ProductDTO employeeDTO);
        Task<int> UpdateProduct(ProductDTO employeeDTO);
        Task<int> UpdateFullProduct(ProductDTO employeeDTO);
        Task<int> DeleteProduct(Guid Id);
        IEnumerable<ProductABCFMRAnalysisDTO> ProductABCFMRanalysis();
    }
}
