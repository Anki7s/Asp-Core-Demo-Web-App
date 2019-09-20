using MvcFirstApp.Models;
using System.Collections.Generic;

namespace MvcFirstApp.Repository
{
    public interface IMovieRepository
    {
        Movie GetMovie(int Id);
        IEnumerable<Movie> GetMovieList();
        Movie Delete(int Id);
        Movie SaveMovie(Movie Movie);
    }
}
