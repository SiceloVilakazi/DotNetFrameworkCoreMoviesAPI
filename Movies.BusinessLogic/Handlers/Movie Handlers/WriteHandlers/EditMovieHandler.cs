using MediatR;

namespace Movies.BusinessLogic;

public class EditMovieHandler : IRequestHandler<EditMovieCommand, int>
{
    private readonly MovieService _movieService;
    public EditMovieHandler(MovieService movieService)
    {
        _movieService = movieService;
    }
    public async Task<int> Handle(EditMovieCommand request, CancellationToken cancellationToken)
    {
        var movieId = await _movieService.EditAsync(request.Movie);
        return movieId;
    }
}

