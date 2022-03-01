

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditActorHandler : IRequestHandler<EditActorCommand, int>
    {
        private readonly ActorService _actorService;

        public EditActorHandler(ActorService actorService)
        {
            _actorService = actorService;
        }
        public async Task<int> Handle(EditActorCommand request, CancellationToken cancellationToken)
        {
            return await _actorService.EditAsync(request.Actor);
        }
    }
}
