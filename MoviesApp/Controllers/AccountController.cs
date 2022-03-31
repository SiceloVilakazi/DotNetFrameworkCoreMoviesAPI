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
       
        [HttpPost]
        public async  Task<IActionResult> GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var validityQuery = new GetUserAvailabilityQuery(userLogins.UserName, userLogins.Password);
                var Valid = await _medator.Send(validityQuery);
               
                if (Valid)
                {
                    var query = new GetUserByUserNameQuery(userLogins.UserName);
                    var user = await _medator.Send(query);
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.EmailId,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = user.Id,
                    }, jwtSettings);
                }
                else
                {
                    return BadRequest($"wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(Users user)
        {
            var command = new AddUserCommand(user);
            await _medator.Send(command);
            return Ok();
        }
    }
}
