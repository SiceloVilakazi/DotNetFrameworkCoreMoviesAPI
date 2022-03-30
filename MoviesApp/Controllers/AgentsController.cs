using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AgentsController : ControllerBase
    {
        private readonly AgentService _agentService;

        public AgentsController(AgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Agent>>> Get()
        {
            return Ok(await _agentService.GetAllAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Agent>> Get(int Id)
        {
            var agent = await _agentService.GetByIdAsync(Id);
            if (agent == null)
                return BadRequest("Movie Does not exist");
            return Ok(agent);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(Agent model)
        {
            if (ModelState.IsValid)
                await _agentService.AddAsync(model);
            return Ok("Movie Saved");
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(Agent model)
        {
            if (ModelState.IsValid)
            {
                await _agentService.EditAsync(model);
            }

            return Ok("Movie edited");
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            await _agentService.RemoveAsync(Id);

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
