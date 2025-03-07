using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPi.Data
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        public string ProductDiscription { get; set; }
        [Range(0, double.MaxValue)]
        public double ProductPrice { get; set; }
        public byte ProductDiscount { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new List<OrderDetails>();
        }

    }
}
