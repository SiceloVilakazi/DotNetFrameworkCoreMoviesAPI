

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorAgentByIdHandler : IRequestHandler<GetActorAgentByIdQuery, ActorAgent>
    {
        private readonly ActorAgentService _actorAgentService;

        public GetActorAgentByIdHandler(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }
        public async Task<ActorAgent> Handle(GetActorAgentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorAgentService.GetByIdAsync(request.ActorAgentId);
        }
    }
}
