namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Hall
    {
        private ICollection<Projection> projections;

        public Hall()
        {
            this.projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

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