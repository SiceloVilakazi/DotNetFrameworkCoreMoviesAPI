using MediatR;

namespace Movies.BusinessLogic;

public class GetActorListQuery : IRequest<List<Actor>>
{
}

