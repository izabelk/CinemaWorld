namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private ICollection<Projection> projections;
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;
        private ICollection<string> actors;

        public Movie()
        {
            this.projections = new HashSet<Projection>();
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
            this.actors = new HashSet<string>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [RegularExpression(@"^\d{4}$")]
        public int Year { get; set; }

        public int Duration { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Projection> Projections
        {
            get
            {
                return this.projections;
            }
            set
            {
                this.projections = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }
            set
            {
                this.votes = value;
            }
        }

        public virtual ICollection<string> Actors
        {
            get
            {
                return this.actors;
            }
            set
            {
                this.actors = value;
            }
        }
    }
}