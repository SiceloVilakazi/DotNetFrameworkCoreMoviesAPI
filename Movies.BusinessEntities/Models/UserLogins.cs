using System.ComponentModel.DataAnnotations;

namespace Movies.BusinessEntities
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public UserLogins() { }

    }
}
