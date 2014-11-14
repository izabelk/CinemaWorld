namespace CinemaWorld.Web.Areas.ViewModels.Cinemas
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class CinemaViewModel : IMapFrom<Cinema>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }
    }
}