

using MediatR;

namespace Movies.BusinessLogic
{
    public class GetMovieActorHandler : IRequestHandler<GetMovieActorListQuery, List<MovieActor>>
    {
        private readonly MovieActorService _movieActorService;

        public GetMovieActorHandler(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService; 
        }

        public async Task<List<MovieActor>> Handle(GetMovieActorListQuery request, CancellationToken cancellationToken)
        {
            return await _movieActorService.GetAllAsync();
        }
    }
}
