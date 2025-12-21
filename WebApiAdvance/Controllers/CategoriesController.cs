using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.DTOs.CategoryDTOs;


namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CategoriesController(ApiDbContext context)
        {
            _context = context;
        }


        //1) Read All
      
        [HttpGet]

        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _context.Categories.ToListAsync();
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        //2) Read id
       
        
        [HttpGet]

        public async Task<IActionResult> GetCategoryId(Guid id)
        {
            {
                var existsCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
                if (existsCategory == null)
                    return NotFound();

                return StatusCode((int)HttpStatusCode.Found, existsCategory);
            }
        }


        //3) Create
      
        
        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            Category category = new Category()
            {
                Name = createCategoryDTO.Name,
                Description = createCategoryDTO.Description,
                Status = createCategoryDTO.Status,
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return NoContent();

        }


        //4) Delete
       
        
        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var existsCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existsCategory == null)
                return NotFound();

            _context.Categories.Remove(existsCategory);
            await _context.SaveChangesAsync();
            return NoContent();


        }


        //5)Update
      
        [HttpPut]

        public async Task<IActionResult>UpdateCategory(Guid id ,UpdateCategoryDTO updateCategoryDTO)
        {
            var existsCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (existsCategory == null)
                return NotFound();

            existsCategory.Name = updateCategoryDTO.Name == null ? existsCategory.Name : updateCategoryDTO.Name;
            existsCategory.Description = updateCategoryDTO.Description == null ? existsCategory.Description: updateCategoryDTO.Description ;
            existsCategory.Status=updateCategoryDTO.Status == null? existsCategory.Status : updateCategoryDTO.Status ;

            _context.Update(existsCategory);
            await _context.SaveChangesAsync();
            return NoContent();


        }


    }
}



   

