

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetAgentListQuery :IRequest<List<Agent>>
    {
    }
}
