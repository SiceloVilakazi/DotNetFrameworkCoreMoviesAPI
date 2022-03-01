

using MediatR;

namespace Movies.BusinessLogic
{
    public class AddActorCommand : IRequest<int>
    {
        public Actor Actor { get; set; }

        public AddActorCommand(Actor actor)
        {
            this.Actor = actor;
        }
    }
}
