namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cinema
    {
        private ICollection<Projection> projections;

        public Cinema()
        {
            this.projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

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
    }
}