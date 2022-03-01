
using MediatR;

namespace Movies.BusinessLogic
{
    public class AddMovieActorCommand : IRequest<int>
    {
        public MovieActor MovieActor { get; set; }
        public AddMovieActorCommand(MovieActor movieActor)
        {
            this.MovieActor = movieActor;       
        }
    }
}
