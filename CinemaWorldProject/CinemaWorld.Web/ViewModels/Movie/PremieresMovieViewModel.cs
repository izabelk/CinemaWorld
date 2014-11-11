namespace CinemaWorld.Web.ViewModels.Movie
{
    using CinemaWorld.Models;

    using CinemaWorld.Web.Infrastructure.Mapping;

    public class PremieresMovieViewModel : HomePageMovieViewModel, IMapFrom<Movie>
    {
        public string Description { get; set; }
    }
}