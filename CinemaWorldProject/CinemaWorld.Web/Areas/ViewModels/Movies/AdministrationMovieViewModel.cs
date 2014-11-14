namespace CinemaWorld.Web.Areas.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.Web.Mvc;

    using AutoMapper;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;
    
    public class AdministrationMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^\d{4}$")]
        public int Year { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        [DefaultValue(false)]
        public bool? IsPremiere { get; set; }

        [DisplayName("Country")]
        [UIHint("Country")]
        public int CountryId { get; set; }

        [Editable(false)]
        [HiddenInput(DisplayValue=false)]
        public string CountryName { get; set; }

        [DisplayName("Category")]
        [UIHint("Category")]
        public int CategoryId { get; set; }

        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string CategoryName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, AdministrationMovieViewModel>()
               .ForMember(m => m.CountryName, opt => opt.MapFrom(u => u.Country.Name));

            configuration.CreateMap<Movie, AdministrationMovieViewModel>()
               .ForMember(m => m.CategoryName, opt => opt.MapFrom(u => u.Category.Name));
        }
    }
}