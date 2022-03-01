
using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorCommand,int>
    {
        private ActorService _actorService; 

        public DeleteActorHandler(ActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<int> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
           return await _actorService.RemoveAsync(request.ActorId);
        }
    }
}
