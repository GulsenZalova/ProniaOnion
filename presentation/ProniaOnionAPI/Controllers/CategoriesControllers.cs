using Microsoft.AspNetCore.Mvc;
using ProniaOnion.src.Application;

namespace ProniaOnion.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        
        public readonly ICategoryService _service; 

        public CategoriesController( ICategoryService categoryService)
        {
            _service = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Get(int page=2,int take=5 )
        {
            // Skip(nece data oturmek lazimdir)
            // Take(nece data goturmek)
            // 25 data
            // 5 page
            // 5 data
            // 1 2 3 4 5 
            var categories=await _service.GetAllAsync(page,take);
        
            return StatusCode(StatusCodes.Status200OK, categories);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id==null || id < 1)
            {
                return BadRequest();
            }

            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            } 

            return StatusCode(StatusCodes.Status200OK, category);
        }   

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDTO createCategoryDTO)
        {
             if(await _service.CreateAsync(createCategoryDTO))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return BadRequest();
             
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             if(id==null || id < 1)
            {
                return BadRequest();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm] UpdateCategoryDTO updateCategoryDTO)
        {
              if(id==null || id < 1)
            {
                return BadRequest();
            }
             await _service.UpdateAsync(id,updateCategoryDTO);
            return NoContent();
        }

    }
    }
