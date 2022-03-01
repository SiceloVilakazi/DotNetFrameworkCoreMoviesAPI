using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorAgentListQuery : IRequest<List<ActorAgent>>
    {
    }
}
