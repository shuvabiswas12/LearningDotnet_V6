using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LearningDotnet_V6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
