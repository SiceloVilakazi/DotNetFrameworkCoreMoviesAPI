using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorAgentsListHandler : IRequestHandler<GetActorAgentListQuery, List<ActorAgent>>
    {
        private readonly ActorAgentService _actorAgentService;

        public GetActorAgentsListHandler(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }

        public async Task<List<ActorAgent>> Handle(GetActorAgentListQuery request, CancellationToken cancellationToken)
        {
            return await _actorAgentService.GetAllAsync();
        }
    }
}
