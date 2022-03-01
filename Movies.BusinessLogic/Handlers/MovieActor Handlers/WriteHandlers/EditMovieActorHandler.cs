

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditMovieActorHandler : IRequestHandler<EditMovieActorCommand, int>
    {
        private MovieActorService _movieActorService;

        public EditMovieActorHandler(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }
        public async Task<int> Handle(EditMovieActorCommand request, CancellationToken cancellationToken)
        {
            return await _movieActorService.EditAsync(request.MovieActor);
        }
    }
}
