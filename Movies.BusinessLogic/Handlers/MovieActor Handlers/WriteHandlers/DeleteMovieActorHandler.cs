

using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteMovieActorHandler : IRequestHandler<DeleteMovieActorCommand, int>
    {
        private readonly MovieActorService _movieActorService;

        public DeleteMovieActorHandler(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }
        public async Task<int> Handle(DeleteMovieActorCommand request, CancellationToken cancellationToken)
        {
            return await _movieActorService.RemoveAsync(request.MovieActorId);
        }
    }
}
