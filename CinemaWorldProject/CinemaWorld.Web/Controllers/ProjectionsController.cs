namespace CinemaWorld.Web.Controllers
{
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
            var projections = this
                .Data
                .Projections
                .All()
                .Project().To<ProjectionViewModel>()
                .GroupBy(p => p.Movie);

            return View();
        }
    }
}