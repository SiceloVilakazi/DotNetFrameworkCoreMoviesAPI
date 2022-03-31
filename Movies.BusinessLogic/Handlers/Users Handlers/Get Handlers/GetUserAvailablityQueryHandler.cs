using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLogic
{
    public class GetUserAvailablityQueryHandler : IRequestHandler<GetUserAvailabilityQuery, bool>
    {
        public readonly UserService _userService;

        public GetUserAvailablityQueryHandler(UserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> Handle(GetUserAvailabilityQuery request, CancellationToken cancellationToken)
        {
           var isValid = await _userService.UserAvailable(request.UserName,request.UserPassword);

            return isValid;
        }
    }
}
