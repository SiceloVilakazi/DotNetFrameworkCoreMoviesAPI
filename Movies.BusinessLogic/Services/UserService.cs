
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

            //A hack for the decoding
            var password = EncodePassword(Password);

            var user = await _context.users.AnyAsync(x=>x.UserName.Trim().ToLower().
            Equals(username) || x.Password.Trim().ToLower().Equals(password));

            //check for the username
            //check for the password of that user
            //decode the password and compare it with code given


            if(user)
              return true;

            return false;
        }


        public async Task<int> AddUser(Users model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                model.Password = EncodePassword(model.Password);
                _context.users.Add(model);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        internal static string EncodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        //Decoding of password still to be used
        internal static string DecodePassword(string decodedPassword)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(decodedPassword);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
