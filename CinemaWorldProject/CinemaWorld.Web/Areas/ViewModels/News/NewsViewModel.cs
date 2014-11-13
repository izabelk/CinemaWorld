namespace CinemaWorld.Web.Areas.ViewModels.News
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class NewsViewModel : IMapFrom<News>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Posted on")]
        public DateTime CreatedOn { get; set; }
    }
}