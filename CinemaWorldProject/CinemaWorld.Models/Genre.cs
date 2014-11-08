namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        private ICollection<Movie> movies;

        public Genre()
        {
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get
            {
                return this.movies;
            }
            set
            {
                this.movies = value;
            }
        }
    }
}