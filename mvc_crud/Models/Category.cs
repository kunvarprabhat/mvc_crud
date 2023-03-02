using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvc_crud.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("DisplayOrder")]
        [Range(1,100,ErrorMessage ="Dispaly Order Must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
    }
}
