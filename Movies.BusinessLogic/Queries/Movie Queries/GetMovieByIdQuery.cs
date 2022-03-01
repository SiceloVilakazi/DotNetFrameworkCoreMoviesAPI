using MediatR;

namespace Movies.BusinessLogic;

public class GetMovieByIdQuery : IRequest<Movie>
{
    public int MovieId {get; }
    public GetMovieByIdQuery(int movieId)
    {
        MovieId = movieId;
    }
}

