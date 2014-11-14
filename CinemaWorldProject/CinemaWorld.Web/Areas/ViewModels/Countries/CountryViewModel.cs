using CinemaWorld.Models;
using CinemaWorld.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaWorld.Web.Areas.ViewModels.Countries
{
    public class CountryViewModel: IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required]
        [Editable(false)]
        public string Name { get; set; }
    }
}