using MediatR;

namespace Movies.BusinessLogic;

public class DeleteMovieCommand :IRequest<int>
{
    public int Id { get;}

    public DeleteMovieCommand(int id)
    {
        Id = id;
    }
}

