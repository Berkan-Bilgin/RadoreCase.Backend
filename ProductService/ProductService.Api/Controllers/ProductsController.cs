using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Api.Data;
using ProductService.Api.Dtos;
using ProductService.Api.Models;
using ProductService.Api.Repositories;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductRepository _repository;
        private IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetListAsync(
                include: query => query
                    .Include(p => p.Category)   // Category'i dahil ediyoruz
                    .Include(p => p.ColorOptions)      // Color'ı dahil ediyoruz
            );

            var productDtos = _mapper.Map<List<ProductListItemDto>>(products);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetAsync(
                predicate: p => p.Id == id,
                include: query => query.Include(p => p.Category)
                                       .Include(p => p.ColorOptions)
            );

            var productDto = _mapper.Map<ProductListItemDto>(product);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto productCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string imgPath = null;

            // Dosya yüklemesi yapılmış mı kontrol edelim
            if (productCreateDto.Img != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", productCreateDto.Img.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await productCreateDto.Img.CopyToAsync(stream);
                }

                imgPath = $"/images/{productCreateDto.Img.FileName}";
            }

            // DTO'yu entity'e dönüştür
            var product = _mapper.Map<Product>(productCreateDto);

            // Dosya yolunu Product entity'sinin Img property'ine atıyoruz
            product.Img = imgPath;

            // Veritabanına kaydet
            await _repository.AddAsync(product);

            // 201 Created response döndür
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(product);

            return NoContent();
        }
    }
}
