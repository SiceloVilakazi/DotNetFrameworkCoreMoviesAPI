using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorNamesByMovieQuery : IRequest<List<string>>
    {
        public string MovieName { get;}
        public GetActorNamesByMovieQuery(string movieName)
        {
            MovieName = movieName;
        }
    }
}
