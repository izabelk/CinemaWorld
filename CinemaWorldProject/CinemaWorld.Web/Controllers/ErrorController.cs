namespace CinemaWorld.Web.Controllers
{
    using System.Web.Mvc;

    using CinemaWorld.Data.UnitOfWork;

    public class ErrorController : BaseController
    {
        public ErrorController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("Error");
        }
    }
}