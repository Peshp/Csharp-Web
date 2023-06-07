using System.ComponentModel.DataAnnotations;
using static Library.Constants.Constants.CategoryConstants;

namespace Library.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set; }
            = new List<Book>();
    }
}
