

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorByIdHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly ActorService _actorService;

        public GetActorByIdHandler(ActorService actorService)
        {
            _actorService = actorService;
        }
        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _actorService.GetByIdAsync(request.ActorId);
        }
    }
}
