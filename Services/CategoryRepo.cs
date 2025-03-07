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
            throw new NotImplementedException();
        }

        public CategoryVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryVM Add(CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CategoryModel category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
