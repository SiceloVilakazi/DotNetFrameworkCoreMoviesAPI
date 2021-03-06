using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentActorController : ControllerBase
    {
        private readonly ActorAgentService _actorAgentService;

        public AgentActorController(ActorAgentService actorAgentService)
        {
            _actorAgentService = actorAgentService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<ActorAgent>>> Get()
        {
            return Ok(await _actorAgentService.GetAllAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ActorAgent>> Get(int Id)
        {
            var actorAgent = await _actorAgentService.GetByIdAsync(Id);
            if (actorAgent == null)
                return BadRequest("Movie Does not exist");
            return Ok(actorAgent);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(ActorAgent model)
        {
            if (ModelState.IsValid)
                await _actorAgentService.AddAsync(model);
            return Ok("Movie Saved");
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(ActorAgent model)
        {
            if (ModelState.IsValid)
            {
                await _actorAgentService.EditAsync(model);
            }

            return Ok("Movie edited");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _actorAgentService.RemoveAsync(Id);

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
