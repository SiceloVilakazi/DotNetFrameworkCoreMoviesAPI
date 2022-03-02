using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _medator;

        public ActorsController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Actor>>> Get()
        {
            var query = new GetActorListQuery();
            var result = await _medator.Send(query);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Actor>> Get(int Id)
        {
            var query = new GetActorByIdQuery(Id);
            var result = await _medator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
        [HttpGet("GetActorsByMovie/{MovieName}")]
        public async Task<ActionResult<List<string>>> GetActorsByMovie(string MovieName)
        {
            var query = new GetActorNamesByMovieQuery(MovieName);
            var result = await _medator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("GetTotalActorsByAgent/{AgentName}")]
        public async Task<ActionResult<int>> GetTotalActorsByAgent(string AgentName)
        {
            var query = new GetTotalActorsByAgentQuery(AgentName);
            var result = await _medator.Send(query);
            return  Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> Add(Actor model)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                var command = new AddActorCommand(model);
                result = await _medator.Send(command);
            }
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> Edit(Actor model)
        {
            var result = 0;
            if (ModelState.IsValid)
            {
                var command = new EditActorCommand(model);
                result = await _medator.Send(command);
            }

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeleteMovieCommand(Id);
            var result = await _medator.Send(command);

            return Ok("Movie " + result + ", deleted");
        }
    }
}
