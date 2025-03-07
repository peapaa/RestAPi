using Microsoft.EntityFrameworkCore;

namespace RestAPi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        #region DbSet 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(o => o.OrderCode);
                entity.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.HasKey(o => new { o.OrderCode, o.ProductId });
                entity.HasOne(o => o.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderCode).HasConstraintName("FK_OrderDetails_Order");
                entity.HasOne(o => o.Product).WithMany(o => o.OrderDetails).HasForeignKey(o => o.ProductId).HasConstraintName("FK_OrderDetails_Product");
            });
        }
    }

}
