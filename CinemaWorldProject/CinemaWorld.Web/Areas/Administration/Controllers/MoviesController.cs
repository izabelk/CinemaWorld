namespace CinemaWorld.Web.Areas.Administration.Controllers
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
    using CinemaWorld.Web.Areas.ViewModels.Categories;
    using CinemaWorld.Web.Areas.ViewModels.Movies;
    using CinemaWorld.Web.Areas.ViewModels.Countries;

    public class MoviesController : AdminController
    {
        public MoviesController(ICinemaWorldData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.PopulateCountries();
            this.PopulateCategories();

            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var dbMovies = this.Data.Movies.All().Project().To<AdministrationMovieViewModel>().ToList();

            //foreach (var movie in dbMovies)
            //{
            //    movie.GenresNames = string.Join(", ", movie.Genres);
            //}

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
                model.CountryName = dbModel.Country.Name;
                model.CategoryName = dbModel.Category.Name;
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdministrationMovieViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var movie = this.Data.Movies.All().FirstOrDefault(m => m.Id == model.Id);
                Mapper.CreateMap<AdministrationMovieViewModel, Movie>();
                Mapper.Map(model, movie);
                this.Data.SaveChanges();
                model.CategoryName = movie.Category.Name;
                model.CountryName = movie.Country.Name;
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

        private void PopulateCountries()
        {
            var countries = this.Data
                .Countries
                .All()
                .Project().To<CountryViewModel>();

            ViewData["countries"] = countries;
            ViewData["defaultCountry"] = countries.FirstOrDefault();
        }

        private void PopulateCategories()
        {
            var categories = this.Data
                .Categories
                .All()
                .OrderBy(c => c.Name)
                .Project().To<CategoryViewModel>();

            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.FirstOrDefault();
        }
    }
}