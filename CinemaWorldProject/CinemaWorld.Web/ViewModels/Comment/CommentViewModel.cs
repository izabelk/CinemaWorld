namespace CinemaWorld.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;

    using CinemaWorld.Models;
    using CinemaWorld.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Comment should be max 500 characters long")]
        public string Content { get; set; }

        public string AuthorUsername { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
               .ForMember(m => m.AuthorUsername, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}