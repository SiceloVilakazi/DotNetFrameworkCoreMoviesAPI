using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _medator;
        private readonly JWTSettings jwtSettings;

        public AccountController(IMediator mediator, JWTSettings jWTSettings)
        {
            this.jwtSettings = jWTSettings;
            _medator = mediator;
        }
        private IEnumerable<Users> logins = new List<Users>() {
            new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "Admin",
                        Password = "Admin",
                },
                new Users() {
                    Id = Guid.NewGuid(),
                        EmailId = "adminakp@gmail.com",
                        UserName = "User1",
                        Password = "Admin",
                }
        };
        [HttpPost]
        public async  Task<IActionResult> GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                //var Valid = logins.Any(x => x.UserName.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));
                var query = new GetUserByUserNameQuery(userLogins.UserName);
                //var isValid = _medator.Send(query);
                //if (isValid)
                //{
                    var user = await _medator.Send(query);
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = user.Id,
                    }, jwtSettings);
                //}
                //else
                //{
                //    return BadRequest($"wrong password");
               // }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
