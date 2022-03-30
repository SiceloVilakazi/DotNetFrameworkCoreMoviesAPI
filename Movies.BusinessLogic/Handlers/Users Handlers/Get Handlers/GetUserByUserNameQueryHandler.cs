using MediatR;

namespace Movies.BusinessLogic
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, Users>
    {
        private readonly UserService _userService;

        public GetUserByUserNameQueryHandler(UserService userService)
        {
            _userService = userService;
        }
        public async Task<Users> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByUserName(request.UserName);
        }
    }
}
