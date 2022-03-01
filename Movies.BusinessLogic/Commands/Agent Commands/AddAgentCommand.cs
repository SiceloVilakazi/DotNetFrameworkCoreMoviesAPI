

using MediatR;

namespace Movies.BusinessLogic
{ 
    public class AddAgentCommand : IRequest<int>
    {
        public Agent Agent { get; set; }

        public AddAgentCommand(Agent agent)
        {
            this.Agent = agent;
        }
    }
}
