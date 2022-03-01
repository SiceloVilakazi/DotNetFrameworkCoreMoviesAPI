using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLogic
{
    public class GetMovieActorByIdHandler : IRequestHandler<GetMovieActorByIdQuery, MovieActor>
    {

        private readonly MovieActorService _movieActorService;

        public GetMovieActorByIdHandler(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }
        public async Task<MovieActor> Handle(GetMovieActorByIdQuery request, CancellationToken cancellationToken)
        {
            return  await _movieActorService.GetByIdAsync(request.MovieActorId);
        }
    }
}
