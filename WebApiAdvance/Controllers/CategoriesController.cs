using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.Entities.Common;
using WebApiAdvance.Entities.DTOs.CategoryDTOs;


namespace WebApiAdvance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }


        //1) Read All

        [HttpGet]

        //public async Task<IActionResult> GetAllCategories()
        //{
        //    var result = await _context.Categories.ToListAsync();
        //    return StatusCode((int)HttpStatusCode.OK, result);
        //}


        public async Task<ActionResult<List<GetCategoryDTO>>> GetAllCategories(int page,int size)
        {
            var categories = await _categoryRepository.GetAllPaginatedAsync(page,size, null);

            var result = _mapper.Map<List<GetCategoryDTO>>(categories);

            return StatusCode((int) HttpStatusCode.OK,result);
        }





        //2) Read id


        [HttpGet]

        public async Task<ActionResult<GetCategoryDTO>> GetCategoryId(Guid id)
        {
            
                var existsCategory = await _categoryRepository.Get (c => c.Id == id);
                if (existsCategory != null)
                {
                    return Ok(_mapper.Map<GetCategoryDTO>(existsCategory));
                }
                return BadRequest(new
                {
                    status = HttpStatusCode.BadRequest,
                    message = "Category tapilmadi"
                });
            
        }

       


        //3) Create


        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = _mapper.Map<Category>(createCategoryDTO);

            
          
            await _categoryRepository.AddAsync(category);
           await _categoryRepository.SaveAsync() ;
            return NoContent();

        }


        //4) Delete
       
        
        [HttpDelete]

        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category.Id);
           await _categoryRepository.SaveAsync();
            return NoContent();


        }


        //5)Update
      
        [HttpPut]

        public async Task<IActionResult>UpdateCategory(Guid id ,UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryRepository.Get (x => x.Id == id);
            if (category ! == null)
            {
                category.Name= updateCategoryDTO.Name == null ? category.Name : updateCategoryDTO.Name;
                category.Description = updateCategoryDTO.Description == null ? category.Description : updateCategoryDTO.Description;
                category.Status= updateCategoryDTO.Status == null ? category.Status : updateCategoryDTO.Status;

               await _categoryRepository.SaveAsync();
                return Ok();

            }
                return BadRequest(new
                {
                    status=HttpStatusCode.BadRequest,
                    message ="category tapilmadi"
                });


           

        }


    }
}



   

