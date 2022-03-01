

using MediatR;

namespace Movies.BusinessLogic;

public class AddMovieHandler : IRequestHandler<AddMovieCommand, int>
{
    private readonly MovieService _movieService;
    public AddMovieHandler(MovieService movieService)
    {
        // context = dataContext;
        _movieService = movieService;
    }

    public async Task<int> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var movieId = await _movieService.AddAsync(request.Movie);
        return movieId;
    }

}

