namespace CinemaWorld.Web.Areas.ViewModels.Halls
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class HallViewModel : IMapFrom<Hall>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public int Number { get; set; }
    }
}