using System.ComponentModel.DataAnnotations;
using static Library.Constants.ModelConstants.BookConstants;

namespace Library.Models
{
    public class BookEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "10.00")]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<CategoryFormModel> Categories { get; set; }
    }
}
