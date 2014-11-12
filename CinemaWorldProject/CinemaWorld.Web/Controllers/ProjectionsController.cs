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

        public ActionResult Search(string date)
        {
            var provider = CultureInfo.InvariantCulture;
            string format = "d";
            var dateValue = DateTime.ParseExact(date, format, provider);

            var projections = this
               .Data
               .Projections
               .All()
               .Where(p => p.ShownOn.Day == dateValue.Day &&
                   p.ShownOn.Year == dateValue.Year &&
                   p.ShownOn.Month == p.ShownOn.Month)
               .Project().To<ProjectionViewModel>()
               .GroupBy(p => p.Movie)
               .ToDictionary(p => p.Key);

            return this.PartialView("_ProgramResult", projections);
        }
    }
}