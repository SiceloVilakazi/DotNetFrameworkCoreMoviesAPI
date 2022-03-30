using MediatR;

namespace Movies.BusinessLogic
{
    public class GetUserByUserNameQuery : IRequest<Users>
    {
        public string UserName { get; set; }

        public GetUserByUserNameQuery(string username)
        {
            UserName = username;
        }
    }
}
