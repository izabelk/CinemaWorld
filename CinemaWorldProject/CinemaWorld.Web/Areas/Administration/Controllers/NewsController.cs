namespace CinemaWorld.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using AutoMapper;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Models;
    using CinemaWorld.Web.Areas.Administration.Controllers.Base;
    using CinemaWorld.Web.Areas.ViewModels.News;
    
    public class NewsController : AdminController
    {
        public NewsController(ICinemaWorldData data) : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var news = this.Data
                .News
                .All()
                .ToDataSourceResult(request, ModelState);

            return this.Json(news);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<News>(model);
                this.Data.News.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var news = this.Data.News.All().FirstOrDefault(n => n.Id == model.Id);
                news.Content = model.Content;
                news.CreatedOn = model.CreatedOn;
                //Mapper.Map(model, news);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, NewsViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var dbModel = Mapper.Map<News>(model);
                this.Data.News.Delete(dbModel);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}