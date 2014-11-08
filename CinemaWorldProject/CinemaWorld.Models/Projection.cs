namespace CinemaWorld.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Projection
    {
        private ICollection<Seat> seats;
        private ICollection<Ticket> tickets;

        public Projection()
        {
            this.seats = new HashSet<Seat>();
            this.tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int HallId { get; set; }

        public virtual Hall Hall { get; set; }

        [Required]
        public DateTime ShownOn { get; set; }

        public virtual ICollection<Seat> Seats
        {
            get
            {
                return this.seats;
            }
            set
            {
                this.seats = value;
            }
        }

        public virtual ICollection<Ticket> Tickets
        {
            get
            {
                return this.tickets;
            }
            set
            {
                this.tickets = value;
            }
        }
    }
}