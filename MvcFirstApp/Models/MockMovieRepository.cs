using MvcFirstApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MvcFirstApp.Models
{
    public class MockMovieRepository : IMovieRepository
    {
        private List<Movie> _movieList;
        public MockMovieRepository()
        {
            _movieList = new List<Movie>()
            {
                new Movie(){
                    Id=1,
                    Title="Mission Mangal",
                    MovieStar="Akshay Kumar",
                    MovieType="Scifi"
                },
                new Movie(){
                    Id = 2,
                    Title = "Jay Ho",
                    MovieStar = "Salman Khan",
                    MovieType = "Family"
                },
                new Movie(){
                    Id = 3,
                    Title = "The Lion King",
                    MovieStar = "qwerty zxcvb",
                    MovieType = "Animation"
                },
                new Movie(){
                    Id = 4,
                    Title = "Avengers end game",
                    MovieStar = "Tony Stark",
                    MovieType = "Sci-fi"
                }
            };
        }

        public Movie GetMovie(int Id)
        {
            return _movieList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Movie> GetMovieList()
        {
            return _movieList;
        }

        public Movie Delete(int Id)
        {
            Movie movie = _movieList.FirstOrDefault(e => e.Id == Id);

            if (movie != null)
            {
                _movieList.Remove(movie);
            }
            return movie;
        }

        public Movie SaveMovie(Movie movie)
        {
            if (movie != null)
            {
                if (movie.Id == 0)
                {
                    movie.Id = _movieList.Max(e => e.Id) + 1;
                    _movieList.Add(movie);
                }
                else
                {
                    Movie movieSave = _movieList.FirstOrDefault(e => e.Id == movie.Id);
                    movieSave.Title = movie.Title;
                    movieSave.MovieStar = movie.MovieStar;
                    movieSave.MovieType = movie.MovieType;
                }
            }
            return movie;
        }
    }
}
