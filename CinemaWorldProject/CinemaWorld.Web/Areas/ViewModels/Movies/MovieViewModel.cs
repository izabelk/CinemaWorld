namespace CinemaWorld.Web.Areas.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class MovieViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Title { get; set; }
    }
}