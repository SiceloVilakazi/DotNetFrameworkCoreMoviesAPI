

using MediatR;

namespace Movies.BusinessLogic
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
    {
        private UserService _userService;

        public AddUserCommandHandler(UserService userService)
        {
            _userService = userService;
        }
        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.AddUser(request.User);
            return user;
        }
    }
}
