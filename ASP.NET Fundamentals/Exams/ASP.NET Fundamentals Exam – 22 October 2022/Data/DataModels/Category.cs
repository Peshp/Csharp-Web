using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.CategoryCosntants;

namespace Library.Data.DataModels
{
    public class Category
    {
        public Category() 
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
