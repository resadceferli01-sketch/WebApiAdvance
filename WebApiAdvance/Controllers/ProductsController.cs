using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.DTOs.ProductDTOs;

namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        IMapper _mapper;

        public ProductsController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        //1)Read All

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _context.Products.ToListAsync();
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        //2) Read id

        [HttpGet]

        public async Task<IActionResult>GetIdProduct(Guid id)
        {
            var existsProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id==id);
            if (existsProduct == null) 
                return NotFound();

            return StatusCode((int) HttpStatusCode.Found,existsProduct);
            

        }


        //3)Create

        [HttpPost]

        public async Task<IActionResult>AddProduct(CreateProductDTO createProductDTO)
        {


            //Product product = new Product()
            //{
            //    Name = createProductDTO.Name,
            //    Description = createProductDTO.Description,
            //    Price = createProductDTO.Price,
            //    DiscountPrice = createProductDTO.DiscountPrice,
            //    Currency = createProductDTO.Currency,
            //    status = createProductDTO.status,
            //    CategoryId = createProductDTO.CategoryId,

            //};

            var product = _mapper.Map<Product>(createProductDTO);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        //4) Delete

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var existsProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existsProduct == null)
                return NotFound();

            _context.Products.Remove(existsProduct);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        //5) Update
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductDTO updateProductDTO)
        {
            var existsProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (existsProduct == null)
                return NotFound();


            //existsProduct.Name = updateProductDTO.Name;
            //existsProduct.Description = updateProductDTO.Description;
            //existsProduct.Price = updateProductDTO.Price;
            //existsProduct.DiscountPrice = updateProductDTO.DiscountPrice;
            //existsProduct.Currency = updateProductDTO.Currency;
            //existsProduct.status = updateProductDTO.status;
            //existsProduct.CategoryId = updateProductDTO.CategoryId;

            _mapper.Map(updateProductDTO,existsProduct);


            
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
