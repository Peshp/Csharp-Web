using System.ComponentModel.DataAnnotations;

namespace TextSplitter.Models
{
    public class TextViewModel
    {
        [MinLength(2), MaxLength(30)]
        [Required]
        public string Text { get; set; }
        public string SplitText { get; set; }
    }
}
