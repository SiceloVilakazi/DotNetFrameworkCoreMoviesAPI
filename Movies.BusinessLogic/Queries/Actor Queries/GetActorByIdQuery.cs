using MediatR;

namespace Movies.BusinessLogic
{
    public class GetActorByIdQuery : IRequest<Actor>
    {
        public int ActorId { get;}

        public GetActorByIdQuery(int id)
        {
            this.ActorId = id;
        }
    }
}
