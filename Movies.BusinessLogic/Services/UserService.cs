
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

        public async Task<bool> UserAvailable(string Username,string Password)
        {
            var username = Username.Trim().ToLower();
            var password = Password.Trim().ToLower();

            var user = await _context.users.AnyAsync(x=>x.UserName.Trim().ToLower().
            Equals(username) || x.Password.Trim().ToLower().Equals(password));

            if(user)
              return true;

            return false;
        }

    }
}
