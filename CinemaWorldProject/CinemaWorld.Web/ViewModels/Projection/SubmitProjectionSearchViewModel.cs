namespace CinemaWorld.Web.ViewModels.Projection
{
    using AutoMapper;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class SubmitProjectionSearchViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        public string Date { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Projection, SubmitProjectionSearchViewModel>()
              .ForMember(m => m.MovieName, opt => opt.MapFrom(u => u.Movie.Title));

            configuration.CreateMap<Projection, SubmitProjectionSearchViewModel>()
              .ForMember(m => m.CinemaName, opt => opt.MapFrom(u => u.Movie.Duration));

            configuration.CreateMap<Projection, SubmitProjectionSearchViewModel>()
                .ForMember(m => m.CityName, opt => opt.MapFrom(u => u.Hall.Cinema.Name));
        }
    }
}