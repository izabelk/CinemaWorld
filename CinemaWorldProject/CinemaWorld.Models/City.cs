namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        private ICollection<Cinema> cinemas;

        public City()
        {
            this.cinemas = new HashSet<Cinema>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Cinema> Cinemas
        {
            get
            {
                return this.cinemas;
            }
            set
            {
                this.cinemas = value;
            }
        }
    }
}