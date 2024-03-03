using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Repositories
{
    public interface IUserProductRepository
    {
        Task<List<Product>> GetProductByUserId(string userId, string type);
        Task<string> CreateUserProduct(UserPDto userP);
        Task<string> deleteUserProduct(UserProductDto dto);
    }
}