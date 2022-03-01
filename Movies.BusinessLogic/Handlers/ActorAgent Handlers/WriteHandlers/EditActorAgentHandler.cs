

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditActorAgentHandler : IRequestHandler<EditActorAgentCommand, int>
    {
        private readonly ActorAgentService _actorAgentService;

        public EditActorAgentHandler(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }

        public async Task<int> Handle(EditActorAgentCommand request, CancellationToken cancellationToken)
        {
            return await _actorAgentService.EditAsync(request.ActorAgent);
        }
    }
}
