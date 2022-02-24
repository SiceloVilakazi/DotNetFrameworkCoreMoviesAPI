using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    } 
        
    [HttpGet("Get")]
    public async Task<ActionResult<List<Movie>>> Get()
    {
        return Ok(await _movieService.GetAllAsync());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Movie>> Get(int Id)
    {
        var movie = await _movieService.GetByIdAsync(Id);
        if (movie == null)
            return BadRequest("Movie Does not exist");
        return Ok(movie);
    }

    [HttpPost("Add")]
    public async Task<ActionResult> Add(Movie model)
    {
        if (ModelState.IsValid)
          await _movieService.AddAsync(model);
        return Ok("Movie Saved");
    }

    [HttpPut("Edit")]
    public async Task<ActionResult> Edit(Movie model)
    {
        if (ModelState.IsValid)
        {
           await _movieService.EditAsync(model);
        }

        return Ok("Movie edited");
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(int Id)
    {
       await _movieService.RemoveAsync(Id);

        return Ok("Movie " +Id+", deleted");
    }

    [HttpGet("Count")]
    public async Task<ActionResult> Count()
    {
        var NumberOfMovies = await _movieService.CountAsync();
        return Ok("there is "+ NumberOfMovies + " movie/movies recorded in the database");
    }
}

