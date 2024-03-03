using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;

namespace myApi.Repositories
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly DevDbContext dbContext;

        public UserProductRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> CreateUserProduct(UserPDto userP)
        {
            if (userP != null)
            {
                foreach (Guid id in userP.ProductId)
                {
                    var data = new UserProduct
                    {
                        UserId = Guid.Parse(userP.UserId),
                        ProductId = id
                    };
                    dbContext.UserProducts.Add(data);
                }
                await dbContext.SaveChangesAsync();
                return "200";
            }
            return "400";
        }

        public async Task<string> deleteUserProduct(UserProductDto dto)
        {
            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var result = await dbContext.UserProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
                if (result != null)
                {
                    dbContext.Remove(result);
                    await dbContext.SaveChangesAsync();
                    return "200";
                }
            }
            return "400";
        }

        public async Task<List<Product>> GetProductByUserId(string userId, string type)
        {
            if (Guid.TryParse(userId, out Guid res))
            {
                var userProduct = await dbContext.UserProducts.Where(x => x.UserId == res && x.Type == type).Include("Product").ToListAsync();
                if (userProduct.Count > 0)
                {
                    var products = userProduct.Select(x => x.Product).ToList();
                    if (products.Count > 0)
                    {
                        // return Ok(new { statusCode = "200", data = products });
                        return products!;
                    }
                }
            }
            // return Ok(new { statusCode = "400", message = "Không thể tìm thấy product" });
            return [];
        }
    }
}