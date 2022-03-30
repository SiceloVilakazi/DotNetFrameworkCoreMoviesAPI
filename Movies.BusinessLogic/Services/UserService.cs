
using Microsoft.EntityFrameworkCore;

namespace Movies.BusinessLogic
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Users> GetUserByUserName(string UserName)
        {
            var search = UserName.Trim().ToLower();
            var user = await (from usr in _context.users
                              where usr.UserName.Trim().ToLower().Equals(UserName) 
                              select usr).FirstOrDefaultAsync();
            return user;
        }

    }
}
