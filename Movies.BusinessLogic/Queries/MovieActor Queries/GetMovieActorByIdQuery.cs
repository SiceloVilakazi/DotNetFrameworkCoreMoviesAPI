using MediatR;

namespace Movies.BusinessLogic
{
    public class GetMovieActorByIdQuery : IRequest<MovieActor>
    {
        public int MovieActorId { get; }

        public GetMovieActorByIdQuery(int movieActorId)
        {
            this.MovieActorId = movieActorId;
        }
    }
}
