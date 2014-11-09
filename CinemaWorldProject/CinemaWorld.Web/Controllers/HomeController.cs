namespace CinemaWorld.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.ViewModels;
   
    [HandleError(View="Error")]
    public class HomeController : BaseController
    {
        public HomeController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var movies = this.Data
                .Movies
                .All()
                .OrderByDescending(m => m.Year)
                .Take(6)
                .Project().To<HomePageMovieViewModel>();

            return View(movies);
        }
    }
}