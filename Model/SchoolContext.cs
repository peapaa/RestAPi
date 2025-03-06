using Microsoft.EntityFrameworkCore;

namespace RestAPi.Model
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public SchoolContext(DbContextOptions options) : base(options)
        {

        }
    }
}
