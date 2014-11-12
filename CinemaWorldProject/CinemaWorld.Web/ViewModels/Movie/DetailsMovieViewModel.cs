namespace CinemaWorld.Web.ViewModels.Movie
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    using AutoMapper;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;
    using CinemaWorld.Web.ViewModels.Comment;

    public class DetailsMovieViewModel : HomePageMovieViewModel, IMapFrom<Movie>, IHaveCustomMappings
    {
        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^\d{4}$")]
        public int Year { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string Country { get; set; }

        public string Category { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public int Votes { get; set; }

        public bool UserCanVote { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
               .ForMember(m => m.Country, opt => opt.MapFrom(u => u.Country.Name));
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
                .ForMember(m => m.Category, opt => opt.MapFrom(u => u.Category.Name));
            configuration.CreateMap<Movie, DetailsMovieViewModel>()
                .ForMember(m => m.Votes, opt => opt.MapFrom(u => u.Votes.Count));
        }
    }
}