namespace CinemaWorld.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}