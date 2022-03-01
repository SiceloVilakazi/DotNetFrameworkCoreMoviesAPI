

using MediatR;

namespace Movies.BusinessLogic;

public class EditMovieCommand : IRequest<int>
{
    public Movie Movie { get; }
    public EditMovieCommand(Movie movie)
    {
        this.Movie = movie;
    }
}

