using Microsoft.Build.Framework;

namespace Library.Data.Entities
{
    public class ApplicationUserBook
    {
        [Required]
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
