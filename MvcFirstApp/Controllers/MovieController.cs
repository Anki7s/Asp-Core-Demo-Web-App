using Microsoft.AspNetCore.Mvc;
using MvcFirstApp.Models;
using MvcFirstApp.Repository;
using System.Collections;


namespace MvcFirstApp.Controllers
{
    [Route("Movie")]
    public class MovieController : Controller
    {
        private IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        [Route("/")]
        [Route("Index")]
        public IActionResult Index()
        {
            IEnumerable model = _movieRepository.GetMovieList();
            return View(model);
        }

        [Route("Save/{id?}")]
        [HttpGet]
        public IActionResult Save(int id)
        {
            return View(_movieRepository.GetMovie(id));
        }

        [Route("Save/{id?}")]
        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("index", _movieRepository.SaveMovie(movie));
            }
            return View(movie);
        }

        [Route("Details/{id?}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            Movie model = _movieRepository.GetMovie(id);
            return View(model);
        }

        [Route("Delete/{id?}")]
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Movie model = _movieRepository.GetMovie(id ?? 1);
            return View(model);
        }

        [Route("Delete/{id?}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Movie model = _movieRepository.Delete(id);
            return RedirectToAction("index");
        }
    }
}