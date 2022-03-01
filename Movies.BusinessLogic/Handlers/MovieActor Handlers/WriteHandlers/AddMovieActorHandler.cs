
using MediatR;

namespace Movies.BusinessLogic
{
    public class AddMovieActorHandler : IRequestHandler<AddMovieActorCommand, int>
    {
        private MovieActorService _movieActorService;

        public AddMovieActorHandler(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        public async Task<int> Handle(AddMovieActorCommand request, CancellationToken cancellationToken)
        {
            return await _movieActorService.AddAsync(request.MovieActor);
        }
    }
}
