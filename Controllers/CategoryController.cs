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
            var listCategories = _context.Categories.ToList();
            return Ok(listCategories);
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
        public IActionResult CreateCategory(CategoryModel model)
        {
            _context.Add(model);
            _context.SaveChanges();

        }
    }
}
