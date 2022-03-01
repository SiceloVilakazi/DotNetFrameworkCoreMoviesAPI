

using MediatR;

namespace Movies.BusinessLogic
{
    public class DeleteActorCommand : IRequest<int>
    {
        public int ActorId { get; set;}

        public DeleteActorCommand(int actorId)
        {
            this.ActorId = actorId;
        }
    }
}
