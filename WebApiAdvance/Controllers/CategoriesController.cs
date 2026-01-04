using AutoMapper;
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
        IMapper _mapper;

        public CategoriesController(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //1) Read All

        [HttpGet]

        //public async Task<IActionResult> GetAllCategories()
        //{
        //    var result = await _context.Categories.ToListAsync();
        //    return StatusCode((int)HttpStatusCode.OK, result);
        //}


        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _context.Categories.AsNoTracking().ToListAsync();

            return Ok(_mapper.Map<List<GetCategoryDTO>>(categories));
        }



        [HttpGet]

        public async Task<ActionResult<List<GetCategoryDTO>>> GetNameCategory()
        {
            var result = await _context.Categories.Select(c => new GetCategoryDTO
            {
                Name = c.Name,
            }).ToListAsync();

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
            var category = _mapper.Map<Category>(createCategoryDTO);

            //Category category = new Category()
            //{
            //    Name = createCategoryDTO.Name,
            //    Description = createCategoryDTO.Description,
            //    Status = createCategoryDTO.Status,
            //};
          
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

            //existsCategory.Name = updateCategoryDTO.Name == null ? existsCategory.Name : updateCategoryDTO.Name;
            //existsCategory.Description = updateCategoryDTO.Description == null ? existsCategory.Description: updateCategoryDTO.Description ;
            //existsCategory.Status=updateCategoryDTO.Status == null? existsCategory.Status : updateCategoryDTO.Status ;

            _mapper.Map(updateCategoryDTO, existsCategory);
          

            
            await _context.SaveChangesAsync();
            return NoContent();


        }


    }
}



   

