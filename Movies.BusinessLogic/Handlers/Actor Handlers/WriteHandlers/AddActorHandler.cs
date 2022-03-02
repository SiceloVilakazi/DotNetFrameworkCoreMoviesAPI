
using MediatR;

namespace Movies.BusinessLogic
{
    public class AddActorHandler : IRequestHandler<AddActorCommand, int>
    {
        private readonly ActorService _actorService;

        public AddActorHandler(ActorService actorService)
        {
            _actorService = actorService;
        }
        public async Task<int> Handle(AddActorCommand request, CancellationToken cancellationToken)
        {
            var createdActor = await _actorService.AddAsync(request.Actor);
            return createdActor;
        }
    }
}
