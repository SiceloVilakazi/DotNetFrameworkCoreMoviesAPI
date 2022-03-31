using MediatR;

namespace Movies.BusinessLogic
{
    public class GetUserAvailabilityQuery : IRequest<bool>
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public GetUserAvailabilityQuery(string username, string userpassword)
        {
            UserName = username;
            UserPassword = userpassword;
        }
    }
}
