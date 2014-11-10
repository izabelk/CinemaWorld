namespace CinemaWorld.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.ViewModels.Movie;


    public class MoviesController : BaseController
    {
        public MoviesController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = this.Data
                .Movies
                .All()
                .Where(m => m.Id == id)
                .Project().To<DetailsMovieViewModel>()
                .FirstOrDefault();

            if (movie == null)
            {
                return HttpNotFound("Movie not found");
            }

            return View(movie);
        }
    }
}