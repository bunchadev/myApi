using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Repositories
{
    public interface IUserCartRepository
    {
        Task<List<Product>> getCartByUser(string id);
        Task<string> createUserCart(UserProductDto dto);
        Task<string> deleteManyUserCarts(UserPDto userP);
        Task<string> deleteOneUserCart(UserProductDto dto);
    }
}