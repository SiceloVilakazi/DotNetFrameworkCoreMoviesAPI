

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetTotalActorsByAgentHandler : IRequestHandler<GetTotalActorsByAgentQuery, int>
    {
        private readonly ActorService _actorService;

        public GetTotalActorsByAgentHandler(ActorService actorService)
        {
            _actorService = actorService;
        }
        public async Task<int> Handle(GetTotalActorsByAgentQuery request, CancellationToken cancellationToken)
        {
            var totalActors = await _actorService.GetTotalActorsByAgent(request.AgentName);
            return totalActors;
        }
    }
}
