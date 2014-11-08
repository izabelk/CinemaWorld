namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Hall
    {
        //private ICollection<Seat> seats;
        private ICollection<Projection> projections;

        public Hall()
        {
            //this.seats = new HashSet<Seat>();
            this.projections = new HashSet<Projection>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        //[MaxLength(2)]
        public int Number { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        //public virtual ICollection<Seat> Seats
        //{
        //    get
        //    {
        //        return this.seats;
        //    }
        //    set
        //    {
        //        this.seats = value;
        //    }
        //}

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