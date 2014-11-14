namespace CinemaWorld.Web.Areas.Administration.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.Controllers;
    using CinemaWorld.Web.Areas.ViewModels.Projections;
    using CinemaWorld.Models;
    using CinemaWorld.Web.Areas.ViewModels.Movies;
    using CinemaWorld.Web.Areas.ViewModels.Halls;

    public class ProjectionsController : BaseController
    {
        public ProjectionsController(ICinemaWorldData data)
            : base(data)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.PopulateMovies();
            this.PopulateHalls();

            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var dbProjections = this
                .Data
                .Projections
                .All()
                .Project()
                .To<ProjectionViewModel>();

            var projections = dbProjections.ToDataSourceResult(request, ModelState);

            return this.Json(projections);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ProjectionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Mapper.CreateMap<ProjectionViewModel, Projection>();
                var dbModel = Mapper.Map<Projection>(model);
                this.Data.Projections.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
                model.MovieName = this.Data.Movies.All().FirstOrDefault(m => m.Id == dbModel.MovieId).Title;
                model.HallNumber = this.Data.Halls.All().FirstOrDefault(h => h.Id == dbModel.HallId).Number;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProjectionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var projection = this.Data.Projections.All().FirstOrDefault(p => p.Id == model.Id);
                Mapper.CreateMap<ProjectionViewModel, Projection>();
                Mapper.Map(model, projection);
                this.Data.SaveChanges();
                model.MovieName = projection.Movie.Title;
                model.HallNumber = projection.Hall.Number;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ProjectionViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Mapper.CreateMap<ProjectionViewModel, Projection>();
                var dbModel = Mapper.Map<Projection>(model);
                this.Data.Projections.Delete(dbModel);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        private void PopulateMovies()
        {
            var movies = this.Data
                .Movies
                .All()
                .Project().To<MovieViewModel>();

            ViewData["movies"] = movies;
            ViewData["defaultMovie"] = movies.FirstOrDefault();
        }

        private void PopulateHalls()
        {
            var halls = this.Data
                .Halls
                .All()
                .Project().To<HallViewModel>();

            ViewData["halls"] = halls;
            ViewData["defaultHall"] = halls.FirstOrDefault();
        }
    }
}