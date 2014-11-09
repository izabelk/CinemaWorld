namespace CinemaWorld.Web.Controllers
{
    using CinemaWorld.Data.UnitOfWork;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(ICinemaWorldData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Program()
        {
            return View();
        }

        public ActionResult News()
        {
            var news = this.Data.News.All();
            return View(news);
        }
    }
}