using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace myApi.Repositories
{
    public class UserCartRepository : IUserCartRepository
    {
        private readonly DevDbContext dbContext;

        public UserCartRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> createUserCart(UserProductDto dto)
        {
            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var userCart = new UserCart
                {
                    ProductId = productId,
                    UserId = userId
                };
                await dbContext.userCarts.AddAsync(userCart);
                await dbContext.SaveChangesAsync();
                return "200";
            }
            return "400";
        }

        public async Task<string> deleteManyUserCarts(UserPDto userP)
        {
            if (Guid.TryParse(userP.UserId, out Guid res))
            {
                var users = await dbContext.userCarts.Where(x => userP.ProductId.Contains(x.ProductId) && x.UserId == res).ToListAsync();
                if (users.Count > 0)
                {
                    dbContext.RemoveRange(users);
                    await dbContext.SaveChangesAsync();
                    return "200";
                }
            }
            return "400";
        }

        public async Task<string> deleteOneUserCart(UserProductDto dto)
        {
            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var userCart = await dbContext.userCarts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
                if (userCart != null)
                {
                    dbContext.userCarts.Remove(userCart);
                    await dbContext.SaveChangesAsync();
                }
                return "200";
            }
            return "400";
        }

        public async Task<List<Product>> getCartByUser(string id)
        {
            if (Guid.TryParse(id, out Guid res))
            {
                var products = await dbContext.userCarts.Where(x => x.UserId == res).Include("product").ToListAsync();
                if (products.Count > 0)
                {
                    var result = products.Select(x => x.product).ToList();
                    return result!;
                }
            }
            return [];
        }
    }
}