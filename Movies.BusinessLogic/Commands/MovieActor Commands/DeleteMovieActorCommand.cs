

using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteMovieActorCommand : IRequest<int>
    {
        public int MovieActorId { get; set; }

        public DeleteMovieActorCommand(int movieActorId)
        {
            this.MovieActorId = movieActorId;
        }
    }
}
