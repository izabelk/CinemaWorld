namespace CinemaWorld.Web.Areas.ViewModels.Genres
{
    using System;
    using System.ComponentModel.DataAnnotations;
 
    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class GenreViewModel : IMapFrom<Genre>, IComparable<GenreViewModel>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(GenreViewModel other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}