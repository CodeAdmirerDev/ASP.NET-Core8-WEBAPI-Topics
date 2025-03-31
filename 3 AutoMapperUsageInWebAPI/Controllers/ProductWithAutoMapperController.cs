using AutoMapper;
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
    public class ProductWithAutoMapperController : ControllerBase
    {
        private readonly ProductDbContext _productDbContext;
        private readonly IMapper _mapper;

        public ProductWithAutoMapperController(ProductDbContext productDbContext, IMapper mapper)
        {
            _productDbContext = productDbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync()
        {
            var products = await _productDbContext.Products.AsNoTracking().ToListAsync();

            //AutoMapper automatically maps the Product list object into the ProductDTO list object
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

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

            // AutoMapper automatically maps the Product object into the ProductDTO object
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDTO>> CreateProductAsync(CreateProductDTO createProductDTO)
        {
 
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            //AutoMapper automatically maps the CreateProductDTO object into the Product object
            var product = _mapper.Map<Product>(createProductDTO);
            product.SerialNumber = "Test";
            product.IsActive  = createProductDTO.StockQuantity > 0;
            product.CreatedDateTime = DateTime.UtcNow;


            //Adding the product to the database
            _productDbContext.Products.Add(product);
           await _productDbContext.SaveChangesAsync();

            //Updating the SerialNumber
            product.SerialNumber = CreateSerailNumber(product);

            //Updating the product in the database
           await _productDbContext.SaveChangesAsync();

            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        private string CreateSerailNumber(Product product)
        {
            return $"{product.CategoryId}-{product.Brand}-{product.Name}-{DateTime.UtcNow.Year}-{product.Id}";
        }

    }
}
