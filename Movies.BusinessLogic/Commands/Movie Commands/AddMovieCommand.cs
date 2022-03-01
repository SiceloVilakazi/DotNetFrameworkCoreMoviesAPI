

using MediatR;

namespace Movies.BusinessLogic;

public class AddMovieCommand : IRequest<int>
{
    public Movie Movie { get; }
    public AddMovieCommand(Movie movie)
    {
        this.Movie = movie;
    }
}

