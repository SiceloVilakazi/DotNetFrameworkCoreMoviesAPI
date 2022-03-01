

using MediatR;

namespace Movies.BusinessLogic
{
    public class EditAgentCommand : IRequest<int>
    {
        public Agent Agent { get; set; }

        public EditAgentCommand(Agent agent)
        {
            this.Agent = agent;
        }
    }
}
