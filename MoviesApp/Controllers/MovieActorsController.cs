using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly MovieActorService _movieActorService;

        public MovieActorsController(MovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<MovieActor>>> Get()
        {
            return Ok(await _movieActorService.GetAllAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<MovieActor>> Get(int Id)
        {
            var movieActor = await _movieActorService.GetByIdAsync(Id);
            if (movieActor == null)
                return BadRequest("Movie Does not exist");
            return Ok(movieActor);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(MovieActor model)
        {
            if (ModelState.IsValid)
                await _movieActorService.AddAsync(model);
            return Ok("Movie Saved");
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(MovieActor model)
        {
            if (ModelState.IsValid)
            {
                await _movieActorService.EditAsync(model);
            }

            return Ok("Movie edited");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _movieActorService.RemoveAsync(Id);

            return Ok("Movie " + Id + ", deleted");
        }

        //[HttpGet("Count")]
        //public async Task<ActionResult> Count()
        //{
        //    var NumberOfMovies = await _movieService.CountAsync();
        //    return Ok("there is " + NumberOfMovies + " movie/movies recorded in the database");
        //}
    }
}
