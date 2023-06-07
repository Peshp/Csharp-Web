using Microsoft.AspNetCore.Identity;

namespace Library.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<ApplicationUserBook> ApplicationUserBooks { get; set; } 
            = new List<ApplicationUserBook>();
    }
}
