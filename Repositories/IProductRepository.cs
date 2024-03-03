using myApi.Dto.Domain;
using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductDto>> GetProductWithType(CheckType checkType);
        Task<ProductById> GetProductById(Guid id, string? userId);
        Task<List<Product>> GetProductBySearch(string query, string? id);
        Task<List<Product>> GetProductByIdUser(Guid id);
        Task<string> CreateProduct(createProduct product);
        Task<string> deleteProduct(Guid id);
        Task<string> UpLoadFileImage(IFormFile file);
    }
}