global using Movies.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Movies.BusinessLogic;

public class MovieService
{
    private readonly DataContext context;

    public MovieService(DataContext dataContext)
    {
        context = dataContext;
    }

    #region Read Methods
    public async Task<List<Movie>> GetAllAsync()
    {
        var movies =await context.movies.ToListAsync();
        return movies;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        var movie = new Movie();
        if(MovieExists(id))
             movie = await context.movies.FirstOrDefaultAsync(x => x.Id == id);

        return movie;
    }

    public async Task<int> CountAsync()
    {
        return await context.movies.CountAsync();
    }
    #endregion

    #region Write Methods
    public async Task<int> AddAsync(Movie movie)
    {
        Validate(movie);
        try
        {
            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
        catch
        {
            throw new InvalidOperationException("Cannot save the movie");
        }
   
    }
    public async Task<int> RemoveAsync(int Id)
    {
        try
        {
            var movie = await context.movies.FirstOrDefaultAsync(x => x.Id == Id);
            if (movie != null)
                context.Remove(movie);
            await context.SaveChangesAsync();
            return Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot remove the movie");
        }
    }

    public async Task<int> EditAsync(Movie movie)
    {
        try
        {
            context.Update(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
        catch
        {
            throw new InvalidOperationException("cannot update the movie");
        }
    }
    #endregion

    #region validation
    internal void Validate(Movie movie)
    {
        if (movie == null)
            throw new ValidationException(string.Format(ErrorMessages.InvalidObject));
        if (movie.Title.Length <= 0 || movie.Title.Length > 50)
            throw new ValidationException(string.Format(ErrorMessages.InvalidTitle));
        if (movie.Description.Length <= 0 || movie.Description.Length > 255)
            throw new ValidationException(string.Format(ErrorMessages.InvalidDescription));
        if(movie.Genre.Length<=0 || movie.Genre.Length>50)
            throw new ValidationException(string.Format(ErrorMessages.InvalidGenre));
        if(movie.Price<0)
            throw new ValidationException(string.Format(ErrorMessages.InvalidPrice));
    }

    internal bool MovieExists(int id)
    {
        var movie =  context.movies.FirstOrDefault(x => x.Id == id);
        if (movie != null)
            return true;
        return false;
    }

    #endregion

}

