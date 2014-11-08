namespace CinemaWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int Number { get; set; }

        public int ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }
    }
}