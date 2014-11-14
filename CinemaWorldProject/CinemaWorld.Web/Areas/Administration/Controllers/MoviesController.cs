﻿namespace CinemaWorld.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Models;
    using CinemaWorld.Web.Areas.Administration.Controllers.Base;
    using CinemaWorld.Web.Areas.ViewModels.Movies;

    public class MoviesController : AdminController
    {
        public MoviesController(ICinemaWorldData data)
            : base(data)
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
            var dbMovies = this.Data.Movies.All().Project().To<AdministrationMovieViewModel>();
            var movies = dbMovies.ToDataSourceResult(request, ModelState);
            return this.Json(movies);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, AdministrationMovieViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Mapper.CreateMap<AdministrationMovieViewModel, Movie>();
                var dbModel = Mapper.Map<Movie>(model);
                this.Data.Movies.Add(dbModel);
                this.Data.SaveChanges();
                model.Id = dbModel.Id;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdministrationMovieViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var movies = this.Data.Movies.All().FirstOrDefault(m => m.Id == model.Id);
                Mapper.CreateMap<AdministrationMovieViewModel, Movie>();
                Mapper.Map(model, movies);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AdministrationMovieViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Mapper.CreateMap<AdministrationMovieViewModel, Movie>();
                var dbModel = Mapper.Map<Movie>(model);
                this.Data.Movies.Delete(dbModel);
                this.Data.SaveChanges();
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}