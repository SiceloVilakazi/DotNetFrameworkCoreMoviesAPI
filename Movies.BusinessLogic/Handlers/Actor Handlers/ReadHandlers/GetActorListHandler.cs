

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorListHandler : IRequestHandler<GetActorListQuery, List<Actor>>
    {
        public readonly ActorService ActorService;

        public GetActorListHandler(ActorService actorService)
        {
            this.ActorService = actorService;
        }
        public async Task<List<Actor>> Handle(GetActorListQuery request, CancellationToken cancellationToken)
        {
            return await ActorService.GetAllAsync();
        }
    }
}
