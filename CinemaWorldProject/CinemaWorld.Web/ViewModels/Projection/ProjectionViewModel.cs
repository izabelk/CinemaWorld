namespace CinemaWorld.Web.ViewModels.Program
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class ProjectionViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Movie { get; set; }

        public int Minutes { get; set; }

        public string Cinema { get; set; }

        public string City { get; set; }

        [Required]
        public DateTime ShownOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Projection, ProjectionViewModel>()
              .ForMember(m => m.Movie, opt => opt.MapFrom(u => u.Movie.Title));

            configuration.CreateMap<Projection, ProjectionViewModel>()
              .ForMember(m => m.Minutes, opt => opt.MapFrom(u => u.Movie.Duration));

            configuration.CreateMap<Projection, ProjectionViewModel>()
                .ForMember(m => m.Cinema, opt => opt.MapFrom(u => u.Hall.Cinema.Name));

            configuration.CreateMap<Projection, ProjectionViewModel>()
                .ForMember(m => m.City, opt => opt.MapFrom(u => u.Hall.Cinema.City.Name));
        }
    }
}