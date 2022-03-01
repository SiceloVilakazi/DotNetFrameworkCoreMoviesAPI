using MediatR;

namespace Movies.BusinessLogic;

public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly MovieService _movieService;
    public GetMovieByIdHandler(MovieService movieService)
    {
        _movieService = movieService;
    }
    public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieService.GetByIdAsync(request.MovieId);
    }
}


