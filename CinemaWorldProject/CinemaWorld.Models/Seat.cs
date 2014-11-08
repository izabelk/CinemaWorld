namespace CinemaWorld.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        //[MaxLength(2)]
        public int Number { get; set; }

        //[Required]
        //public int HallId { get; set; }

        //public virtual Hall Hall { get; set; }

        public int ProjectionId { get; set; }

        public virtual Projection Projection { get; set; }
    }
}