using MediatR;

namespace Movies.BusinessLogic;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, int>
{
    private readonly MovieService _movieService;

    public DeleteMovieHandler(MovieService movieService)
    {
        _movieService = movieService;
    }
    public async Task<int> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieService.RemoveAsync(request.Id);
        return movie;
    }
}

