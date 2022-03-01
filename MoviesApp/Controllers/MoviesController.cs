using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MoviesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
   // private readonly MovieService _movieService;
    private readonly IMediator _medator;

    public MoviesController(IMediator mediator)
    {
      //  _movieService = movieService;
        _medator = mediator;
    } 
        
    [HttpGet("Get")]
    public async Task<ActionResult<List<Movie>>> Get()
    {
        var query = new GetMoviesListQuery();
        var result= await _medator.Send(query);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Movie>> Get(int Id)
    {
        var query = new GetMovieByIdQuery(Id);
        var result = await _medator.Send(query);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("Add")]
    public async Task<ActionResult> Add(Movie model)
    {
        var result=0;
        if (ModelState.IsValid)
        {
            var command = new AddMovieCommand(model);
            result = await _medator.Send(command);
        }
        return StatusCode((int)HttpStatusCode.Created, result);
    }

    [HttpPut("Edit")]
    public async Task<ActionResult> Edit(Movie model)
    {
        var result = 0;
        if (ModelState.IsValid)
        {
            var command = new EditMovieCommand(model);
            result = await _medator.Send(command);
        }

        return StatusCode((int)HttpStatusCode.OK, result);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(int Id)
    {
        var command = new DeleteMovieCommand(Id);
        var result = await _medator.Send(command);

        return Ok("Movie " +result+", deleted");
    }

    //[HttpGet("Count")]
    //public async Task<ActionResult> Count()
    //{
    //    var NumberOfMovies = await _movieService.CountAsync();
    //    return Ok("there is "+ NumberOfMovies + " movie/movies recorded in the database");
    //}
}

