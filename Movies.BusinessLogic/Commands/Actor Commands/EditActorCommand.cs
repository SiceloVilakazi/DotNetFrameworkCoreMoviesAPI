

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditActorCommand : IRequest<int>
    {
        public Actor Actor { get; set; }

        public EditActorCommand(Actor actor)
        {
            this.Actor = actor;
        }
    }
}
