using MediatR;

namespace Movies.BusinessLogic;

public class GetMoviesListQuery : IRequest<List<Movie>>
{
}
