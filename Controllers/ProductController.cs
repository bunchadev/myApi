using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Dto.Domain;
using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public ProductController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        // [JwtAuthorization("admin")]
        public async Task<IActionResult> GetProductWithType([FromBody] CheckType checkType)
        {
            var products = await dbContext.Products.Where(x => x.Type == checkType.Type).ToListAsync();
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
                return Ok(new { statusCode = "200", data = result });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id, [FromBody] string? userId)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (Guid.TryParse(userId, out Guid res))
            {
                var userProduct = await dbContext.UserProducts.FirstOrDefaultAsync(x => x.UserId == res && x.ProductId == id);
                var userCart = await dbContext.userCarts.FirstOrDefaultAsync(x => x.UserId == res && x.ProductId == id);
                if (userProduct != null && product != null)
                {
                    return Ok(new { statusCode = "200", data = product, check = true, checkType = true });
                }
                else if (userCart != null && product != null)
                {
                    return Ok(new { statusCode = "200", data = product, check = true, checkType = false });
                }
                else if (product != null)
                {
                    return Ok(new { statusCode = "200", data = product, check = false, checkType = false });
                }
            }
            if (product != null)
            {
                return Ok(new { statusCode = "200", data = product, check = false });
            }
            return Ok(BadRequest());
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetProductBySearch([FromQuery] string query, [FromQuery] string? id)
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
                    return Ok(new { statusCode = "200", data = products, q = newString });
                }
                else
                {
                    return Ok(new { statusCode = "400", message = "Can not find product", q = query });
                }
            }
            return Ok(null);
        }
        [HttpPost]
        [Route("one/{id:guid}")]
        public async Task<IActionResult> GetProductByIdUser([FromRoute] Guid id)
        {
            var product = await dbContext.Products.Where(x => x.Id == id).ToListAsync();
            if (product != null)
            {
                return Ok(new { statusCode = "200", data = product });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody] createProduct product)
        {
            if (ModelState.IsValid)
            {
                using (var transaction = await dbContext.Database.BeginTransactionAsync())
                {
                    try
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
                            await transaction.CommitAsync();

                            return Ok(new { statusCode = "200", id = data1.Id });
                        }
                        else
                        {
                            return BadRequest(new { statusCode = "400", message = "Invalid UserId" });
                        }
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return BadRequest(new { statusCode = "500", message = ex.Message });
                    }
                }
            }
            else
            {
                return BadRequest(new { statusCode = "400", message = "Invalid data" });
            }
        }
        [HttpPost]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> createProduct([FromRoute] Guid id)
        {

            var result = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                dbContext.Products.Remove(result);
                await dbContext.SaveChangesAsync();
                return Ok(new { statusCode = "200" });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UpLoadFileImage([FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("File not selected");

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var filePath = Path.Combine(uploadsFolder, file.FileName);

                if (System.IO.File.Exists(filePath))
                {
                    return Ok(new { statusCode = "400" });
                }
                else
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return Ok(new { statusCode = "200" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}