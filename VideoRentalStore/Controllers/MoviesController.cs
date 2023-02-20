using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoRentalStore.Models;
using VideoRentalStore.ViewModels;

namespace VideoRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // To dispose DbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET : /movies
        [HttpGet]
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        // GET : /movies/details/1
        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET : /movies/new
        [HttpGet]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),
            };
            return View("MovieForm", viewModel);
        }

        // GET : /movies/edit
        [HttpGet]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
            };
            return View("MovieForm", viewModel);
        }

        // POST : /movies/save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.canManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList(),
                };
                return View("MovieForm", viewModel);
            }
            movie.DateAdded = DateTime.Now;
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieInDb == null)
                {
                    return HttpNotFound();
                }
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}