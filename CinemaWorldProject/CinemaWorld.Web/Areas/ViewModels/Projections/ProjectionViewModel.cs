namespace CinemaWorld.Web.Areas.ViewModels.Projections
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using AutoMapper;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class ProjectionViewModel : IMapFrom<Projection>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Movie")]
        [UIHint("Movie")]
        public int MovieId { get; set; }

        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string MovieName { get; set; }

        [DisplayName("Hall")]
        [UIHint("Hall")]
        public int HallId { get; set; }

        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int HallNumber { get; set; }

        [DisplayName("Cinema")]
        [UIHint("Cinema")]
        public int CinemaId { get; set; }

        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public string CinemaName { get; set; }

        [Required]
        public DateTime ShownOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Projection, ProjectionViewModel>()
               .ForMember(p => p.MovieName, opt => opt.MapFrom(u => u.Movie.Title));

            configuration.CreateMap<Projection, ProjectionViewModel>()
              .ForMember(p => p.HallNumber, opt => opt.MapFrom(u => u.Hall.Number));

            configuration.CreateMap<Projection, ProjectionViewModel>()
              .ForMember(p => p.CinemaName, opt => opt.MapFrom(u => u.Hall.Cinema.Name));

            configuration.CreateMap<Projection, ProjectionViewModel>()
             .ForMember(p => p.CinemaId, opt => opt.MapFrom(u => u.Hall.CinemaId));
        }
    }
}