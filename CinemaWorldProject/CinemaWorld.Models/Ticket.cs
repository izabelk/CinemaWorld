namespace CinemaWorld.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public int ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }
    }
}
