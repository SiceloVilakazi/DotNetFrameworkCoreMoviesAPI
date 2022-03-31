using MediatR;

namespace Movies.BusinessLogic
{
    public class AddUserCommand : IRequest<int>
    {
        public Users User { get; set; }

        public AddUserCommand(Users user)
        {
            this.User = user;
        }

    }
}
