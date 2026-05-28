using UESAN.SHOPPING.CORE.Core.DTOs;

namespace UESAN.SHOPPING.CORE.Core.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(ProductCreateDTO productCreateDTO);
        Task DeleteProduct(int id);
        Task<ProductListDTO> GetProductByID(int id);
        Task<IEnumerable<ProductListDTO>> GetProducts();
        Task UpdateProduct(ProductUpdateDTO productUpdateDTO);
    }
}