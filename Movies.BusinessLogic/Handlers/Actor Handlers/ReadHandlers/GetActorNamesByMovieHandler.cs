using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorNamesByMovieHandler : IRequestHandler<GetActorNamesByMovieQuery, List<string>>
    {
        private ActorService _actorService;

        public GetActorNamesByMovieHandler(ActorService actorService)
        {
            _actorService = actorService;
        }

        public async Task<List<string>> Handle(GetActorNamesByMovieQuery request, CancellationToken cancellationToken)
        {
            var actors= await _actorService.GetActorsByMovie(request.MovieName);
            var actorNames = actors.Select(e => e.FullName).ToList();
            return actorNames;
        }
    }
}
