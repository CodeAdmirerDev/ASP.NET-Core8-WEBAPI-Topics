using AutoMapperUsageInWebAPI.Data;
using AutoMapperUsageInWebAPI.Models;
using AutoMapperUsageInWebAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperUsageInWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWithoutAutoMapperController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;

        public ProductWithoutAutoMapperController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var productDTOs = await _productDbContext.Products.AsNoTracking().Select(product => new ProductDTO
            {
                Id = product.Id,
                ProductName = product.Name, //Mapping Name to ProductName
                ProductPrice = product.Price,
                SerialNumber = product.SerialNumber,
                IsActive = product.IsActive,
                ProductDescription = product.Description, //Mapping Description to ProductDescription
                CategoryId = product.CategoryId,
                Brand = product.Brand,
                CreatedDateTime = product.CreatedDateTime
            }).ToListAsync();

            return Ok(productDTOs);
        }

        [HttpGet("GetProductByIdAsync/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var product = await _productDbContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                ProductName = product.Name, //Mapping Name to ProductName
                ProductPrice = product.Price,
                SerialNumber = product.SerialNumber,
                IsActive = product.IsActive,
                ProductDescription = product.Description, //Mapping Description to ProductDescription
                CategoryId = product.CategoryId,
                Brand = product.Brand,
                CreatedDateTime = product.CreatedDateTime
            };

            return Ok(productDTO);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDTO>> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var product = new Product
            {
                Name = createProductDTO.Name,
                Price = createProductDTO.Price,
                Description = createProductDTO.Description,
                CategoryId = createProductDTO.CategoryId,
                Brand = createProductDTO.Brand,
                CreatedDateTime = DateTime.UtcNow,
                IsActive = createProductDTO.StockQuantity > 0,
                StockQuantity = createProductDTO.StockQuantity,
                SupplierName = createProductDTO.SupplierName,
                SupplierPrice = createProductDTO.SupplierPrice,
                SerialNumber = "Test"
            };

            //Adding the product to the database
            _productDbContext.Products.Add(product);
           await _productDbContext.SaveChangesAsync();

            //Updating the SerialNumber
            product.SerialNumber = CreateSerailNumber(product);

            //Updating the product in the database
           await _productDbContext.SaveChangesAsync();

            var productDTO = new ProductDTO
            {
                Id = product.Id,
                ProductName = product.Name, //Mapping Name to ProductName
                ProductPrice = product.Price,
                SerialNumber = product.SerialNumber,
                IsActive = product.IsActive,
                ProductDescription = product.Description, //Mapping Description to ProductDescription
                CategoryId = product.CategoryId,
                Brand = product.Brand,
                CreatedDateTime = product.CreatedDateTime
            };

            return Ok(productDTO);
        }

        private string CreateSerailNumber(Product product)
        {
            return $"{product.CategoryId}-{product.Brand}-{product.Name}-{DateTime.UtcNow.Year}-{product.Id}";
        }

    }
}
