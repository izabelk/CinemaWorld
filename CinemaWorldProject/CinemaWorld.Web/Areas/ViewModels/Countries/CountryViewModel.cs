namespace CinemaWorld.Web.Areas.ViewModels.Countries
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class CountryViewModel: IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }
    }
}