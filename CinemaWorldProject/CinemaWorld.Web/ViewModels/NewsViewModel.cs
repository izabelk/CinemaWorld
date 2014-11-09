namespace CinemaWorld.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}