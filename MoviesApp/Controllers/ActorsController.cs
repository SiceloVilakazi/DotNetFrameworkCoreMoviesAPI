using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorService _actorService;

        public ActorsController(ActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Actor>>> Get()
        {
            return Ok(await _actorService.GetAllAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Actor>> Get(int Id)
        {
            var actor = await _actorService.GetByIdAsync(Id);
            if (actor == null)
                return BadRequest("Actor Does not exist");
            return Ok(actor);
        }
        [HttpGet("GetActorsByMovie/{MovieName}")]
        public async Task<ActionResult<List<Actor>>> GetActorsByMovie(string MovieName)
        {
            var actors = await _actorService.GetActorsByMovie(MovieName);
            return Ok(actors);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(Actor model)
        {
            if (ModelState.IsValid)
                await _actorService.AddAsync(model);
            return Ok("Actor Saved");
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                await _actorService.EditAsync(model);
            }

            return Ok("Actor edited");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _actorService.RemoveAsync(Id);

            return Ok("Actor " + Id + ", deleted");
        }
    }
}
