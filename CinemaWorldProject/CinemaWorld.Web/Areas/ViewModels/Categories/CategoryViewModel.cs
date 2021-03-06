﻿namespace CinemaWorld.Web.Areas.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }
    }
}