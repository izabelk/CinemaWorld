namespace CinemaWorld.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cinema
    {
        private ICollection<Hall> halls;

        public Cinema()
        {
            this.halls = new HashSet<Hall>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Hall> Halls
        {
            get
            {
                return this.halls;
            }
            set
            {
                this.halls = value;
            }
        }
    }
}