using System.ComponentModel.DataAnnotations;
using static Library.Constants.DataConstants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
