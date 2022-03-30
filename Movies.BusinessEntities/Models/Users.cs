
using System.ComponentModel.DataAnnotations;

namespace Movies.BusinessEntities
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
