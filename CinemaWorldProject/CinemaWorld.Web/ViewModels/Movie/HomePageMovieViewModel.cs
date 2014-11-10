namespace CinemaWorld.Web.ViewModels.Movie
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class HomePageMovieViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}