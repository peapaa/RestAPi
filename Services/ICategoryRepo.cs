using RestAPi.Model;

namespace RestAPi.Services
{
    public interface ICategoryRepo
    {
        public interface ICategoryRepo
        {
            List<CategoryVM> GetAll();
            CategoryVM GetById(int id);
            CategoryVM Add(CategoryModel category);
            void Update(int id, CategoryModel category);
            void Delete(int id);

        }
    }
}
