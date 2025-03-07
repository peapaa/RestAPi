using Microsoft.AspNetCore.Mvc;
using RestAPi.Data;
using RestAPi.Model;

namespace RestAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                var listCategories = _context.Categories.ToList();
                return Ok(listCategories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(category => category.CategoryId == id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateCategory(CategoryModel model)
        {
            try
            {

                var category = new Category
                {
                    CategoryName = model.Name
                };
                _context.Add(category);
                _context.SaveChanges();
                //return Ok(category);
                return StatusCode(StatusCodes.Status201Created, category);
            }

            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoryModel model)
        {
            var category = _context.Categories.SingleOrDefault(category => category.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = model.Name;
            _context.SaveChanges();
            //return Ok(category);
            return StatusCode(StatusCodes.Status204NoContent, category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var category = _context.Categories.SingleOrDefault(category => category.CategoryId == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
                //return Ok(category);
                return StatusCode(StatusCodes.Status200OK, category);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
