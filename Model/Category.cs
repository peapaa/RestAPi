using System.ComponentModel.DataAnnotations;

namespace RestAPi.Model
{
    public class CategoryModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


    }

}
