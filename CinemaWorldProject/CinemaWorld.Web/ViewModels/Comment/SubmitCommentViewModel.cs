namespace CinemaWorld.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class SubmitCommentViewModel : IMapFrom<Comment>
    {
        [Required]
        [MaxLength(500, ErrorMessage = "Comment should be max 500 characters long")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Movie is required")]
        public int MovieId { get; set; }
    }
}