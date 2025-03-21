using RestAPi.Data;
using RestAPi.Model;

namespace RestAPi.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MyDbContext _context;

        public CategoryRepo(MyDbContext context)
        {
            _context = context;
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.Categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
            return categories;
        }

        public CategoryVM? GetById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                return new CategoryVM
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
            }
            return null;
        }

        public CategoryVM Add(CategoryModel category)
        {
            var newCategory = new Category
            {
                CategoryName = category.Name
            };
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryId = newCategory.CategoryId,
                CategoryName = newCategory.CategoryName
            };
        }

        public void Update(int id, CategoryModel category)
        {
            var categoryUpdated = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoryUpdated != null)
            {
                categoryUpdated.CategoryName = category.Name;
                _context.SaveChanges();

            }
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
