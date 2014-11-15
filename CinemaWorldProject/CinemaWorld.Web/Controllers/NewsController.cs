namespace CinemaWorld.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Web.ViewModels.News;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;


    [HandleError]
    public class NewsController : BaseController
    {
        public NewsController(ICinemaWorldData data)
            : base(data)
        {
        }

        [HttpGet]
        [OutputCache(Duration = 60, VaryByParam = "none")]
        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult GetNews([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllNews().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        private IQueryable<NewsViewModel> GetAllNews()
        {
            var news = this.Data
                 .News
                 .All()
                 .Project().To<NewsViewModel>();

            return news;
        }
    }
}