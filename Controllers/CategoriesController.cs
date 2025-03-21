using Microsoft.AspNetCore.Mvc;
using RestAPi.Services;

namespace RestAPi.Controllers
{
    public class CategoriesController : Controller
    {
        public readonly ICategoryRepo _categoryRepository;
        public CategoriesController(ICategoryRepo categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
