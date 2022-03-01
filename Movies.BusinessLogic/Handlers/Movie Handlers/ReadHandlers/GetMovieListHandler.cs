using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Movies.BusinessLogic;

public class GetMovieListHandler : IRequestHandler<GetMoviesListQuery, List<Movie>>
{
    private readonly MovieService _movieService;

    public GetMovieListHandler(MovieService movieService)
    {
        _movieService = movieService;
    }

    public async Task<List<Movie>> Handle(GetMoviesListQuery request, CancellationToken cancellationToken)
    {
        return await _movieService.GetAllAsync();
    }
}

