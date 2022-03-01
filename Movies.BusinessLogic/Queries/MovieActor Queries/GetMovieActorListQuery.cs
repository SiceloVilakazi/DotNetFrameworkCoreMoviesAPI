
using MediatR;

namespace Movies.BusinessLogic
{
    public class GetMovieActorListQuery : IRequest<List<MovieActor>>
    {
    }
}
