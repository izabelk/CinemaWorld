namespace CinemaWorld.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.ViewModels.Program;
    using CinemaWorld.Web.ViewModels.Projection;

    public class ProjectionsController : BaseController
    {
        public ProjectionsController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var expiredDate = new DateTime(1500, 1, 1);

            var projections = this
                .Data
                .Projections
                .All()
                .Where(p => p.ShownOn == expiredDate)
                .Project().To<ProjectionViewModel>()
                .GroupBy(p => p.Movie)
                .ToDictionary(p => p.Key);

            return View(projections);
        }

        public JsonResult GetProjectionCityData()
        {
            var result = this.Data.Cities
                .All()
                .Select(c => new
                {
                    City = c.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectionCinemaData()
        {
            var result = this.Data.Cinemas
                .All()
                .Select(c => new
                {
                    Cinema = c.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProjectionMovieData(string Movie)
        {
            var result = this.Data.Movies
                  .All()
                  .Select(m => new
                  {
                      Movie = m.Title
                  });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(SubmitProjectionSearchViewModel model)
        {
            var projections = this.Data.Projections.All();

            if (model.Date != null)
            {
                var provider = CultureInfo.InvariantCulture;
                string format = "d";
                var dateValue = DateTime.ParseExact(model.Date, format, provider);
                projections = projections
                    .Where(p => p.ShownOn.Day == dateValue.Day &&
                    p.ShownOn.Year == dateValue.Year &&
                    p.ShownOn.Month == p.ShownOn.Month);
            }

            if (model.CinemaName != "All")
            {
                projections = projections.Where(p => p.Hall.Cinema.Name == model.CinemaName);
            }

            if (model.CityName != "All")
            {
                projections = projections.Where(p => p.Hall.Cinema.City.Name == model.CityName);
            }

            if (model.MovieName != "All")
            {
                projections = projections.Where(p => p.Movie.Title == model.MovieName);
            }

            var endResult = projections
               .Project().To<ProjectionViewModel>()
               .GroupBy(p => p.Movie)
               .ToDictionary(p => p.Key);

            return this.PartialView("_ProgramResult", endResult);
        }
    }
}