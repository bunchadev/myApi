using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using myApi.Dto.Domain;

namespace myApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevDbContext dbContext;

        public ProductRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> CreateProduct(createProduct product)
        {
            var data1 = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Author = product.Author,
                Evaluate = 3,
                Price = product.Price,
                Type = product.Type,
                FileName = product.FileName
            };
            var result = await dbContext.Products.AddAsync(data1);
            await dbContext.SaveChangesAsync();
            if (Guid.TryParse(product.UserId, out Guid userId) && result != null)
            {
                var data2 = new UserProduct
                {
                    UserId = userId,
                    ProductId = data1.Id,
                    Type = "TG"
                };

                await dbContext.UserProducts.AddAsync(data2);
                await dbContext.SaveChangesAsync();
                return "200";
            }
            else
            {
                return "400";
            }
        }

        public async Task<string> deleteProduct(Guid id)
        {
            var result = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                dbContext.Products.Remove(result);
                await dbContext.SaveChangesAsync();
                return "200";
            }
            return "400";
        }

        public async Task<ProductById> GetProductById(Guid id, string? userId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (Guid.TryParse(userId, out Guid res))
            {
                var userProduct = await dbContext.UserProducts.FirstOrDefaultAsync(x => x.UserId == res && x.ProductId == id);
                var userCart = await dbContext.userCarts.FirstOrDefaultAsync(x => x.UserId == res && x.ProductId == id);
                if (userProduct != null && product != null)
                {
                    // return Ok(new { statusCode = "200", data = product, check = true, checkType = true });
                    var result = new ProductById
                    {
                        statusCode = "200",
                        data = product,
                        check = true,
                        checkType = true
                    };
                    return result;
                }
                else if (userCart != null && product != null)
                {
                    // return Ok(new { statusCode = "200", data = product, check = true, checkType = false });
                    var result = new ProductById
                    {
                        statusCode = "200",
                        data = product,
                        check = true,
                        checkType = false
                    };
                    return result;
                }
                else if (product != null)
                {
                    // return Ok(new { statusCode = "200", data = product, check = false, checkType = false });
                    var result = new ProductById
                    {
                        statusCode = "200",
                        data = product,
                        check = false,
                        checkType = false
                    };
                    return result;
                }
            }
            if (product != null)
            {
                // return Ok(new { statusCode = "200", data = product, check = false, checkType = false });
                var result = new ProductById
                {
                    statusCode = "200",
                    data = product,
                    check = false,
                    checkType = false
                };
                return result;
            }
            return new ProductById { statusCode = "400" };
        }

        public async Task<List<Product>> GetProductByIdUser(Guid id)
        {
            var products = await dbContext.Products.Where(x => x.Id == id).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetProductBySearch(string query, string? id)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var newString = id?.Substring(0, id.Length - 1);
                var products = await dbContext.Products.Where(p => p.Description.ToLower().Contains(query.ToLower())).ToListAsync();
                if (Guid.TryParse(newString, out Guid res))
                {
                    var UserProduct = await dbContext.UserProducts.Where(x => x.UserId == res && x.Type == "KH").ToListAsync();
                    if (UserProduct.Count > 0)
                    {
                        products = products.Where(x => !UserProduct.Any(y => y.ProductId == x.Id)).ToList();
                    }
                }
                if (products.Count > 0)
                {
                    return products;
                }
                else
                {
                    return [];
                }
            }
            return [];
        }
        public async Task<List<ProductDto>> GetProductWithType(CheckType checkType)
        {
            var products = await dbContext.Products.Where(x => x.Type == checkType.Type).OrderByDescending(x => x.Evaluate).ToListAsync();
            if (Guid.TryParse(checkType.UserId, out Guid res))
            {
                var UserProduct = await dbContext.UserProducts.Where(x => x.UserId == res && x.Type == "KH").ToListAsync();
                if (UserProduct.Count > 0)
                {
                    products = products.Where(x => !UserProduct.Any(y => y.ProductId == x.Id)).ToList();
                }
            }
            if (products.Count > 0)
            {
                var result = products.Select(x =>
                    new ProductDto
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Description = x.Description,
                        Author = x.Author,
                        NumberStudents = x.NumberStudents,
                        Evaluate = x.Evaluate,
                        Price = x.Price,
                        Type = x.Type,
                        FileName = x.FileName,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt
                    }).ToList();
                return result;
            }
            return [];
        }
        public async Task<string> UpLoadFileImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return "500";

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, file.FileName);

                if (File.Exists(filePath))
                {
                    return "400";
                }
                else
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return "200";
                }
            }
            catch (Exception ex)
            {
                return $"Internal server error: {ex}";
            }
        }
    }
}