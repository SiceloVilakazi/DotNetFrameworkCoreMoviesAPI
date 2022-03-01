

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditMovieActorCommand : IRequest<int>
    {
        public MovieActor MovieActor { get; set; }

        public EditMovieActorCommand(MovieActor movieActor)
        {
            this.MovieActor = movieActor;
        }
    }
}
