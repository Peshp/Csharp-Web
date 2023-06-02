using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.ApplicationUserConsants;

namespace Library.Data.DataModels
{
    public class ApplicationUser
    {
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new HashSet<ApplicationUser>();
    }
}
