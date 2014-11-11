namespace CinemaWorld.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.ViewModels.Movie;

    public class PremieresController : BaseController
    {
        public PremieresController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var premieres = this.Data.Movies
                .All()
                .Where(m => m.IsPremiere == true)
                .Project().To<PremieresMovieViewModel>();

            return View(premieres);
        }

        public ActionResult GetFullMovieDescription(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("There is no such film");
            }

            var description = this.Data
                .Movies
                .All()
                .Where(m => m.Id == id)
                .FirstOrDefault().Description;

            return Content(description);
        }
    }
}