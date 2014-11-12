namespace CinemaWorld.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;

    using CinemaWorld.Data.UnitOfWork;
    using CinemaWorld.Models;
    using CinemaWorld.Web.ViewModels.Comment;
    using CinemaWorld.Web.ViewModels.Movie;
    
    public class MoviesController : BaseController
    {
        public MoviesController(ICinemaWorldData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var movie = this.Data
                .Movies
                .All()
                .Where(m => m.Id == id)
                .Project().To<DetailsMovieViewModel>()
                .FirstOrDefault();

            if (movie == null)
            {
                return HttpNotFound("Movie not found");
            }
            else
            {
                movie.UserCanVote = !this.Data
                    .Movies
                    .All()
                    .FirstOrDefault(m => m.Id==id)
                    .Votes.Any(v => v.UserId == User.Identity.GetUserId());
            }

            return View(movie);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentViewModel comment)
        {
            var username = this.User.Identity.GetUserName();
            var userId = this.User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                this.Data.Comments.Add(new Comment()
                {
                    AuthorId = userId,
                    Content = comment.Content,
                    MovieId = comment.MovieId,
                });

                this.Data.SaveChanges();
            }

            var viewModel = new CommentViewModel { AuthorUsername = username, Content = comment.Content };
            return PartialView("_CommentPartial", viewModel);
        }

        public ActionResult Vote(int id)
        {
            var userId = User.Identity.GetUserId();

            var canVote = !this.Data.Votes.All().Any(v => v.MovieId == id && v.UserId == userId);

            if (canVote)
            {
                var movie = this.Data
                    .Movies
                    .All()
                    .FirstOrDefault(m => m.Id == id);

                if (movie != null)
                {
                    movie.Votes.Add(new Vote
                    {
                        MovieId = id,
                        UserId = userId
                    });

                    this.Data.SaveChanges();
                }
                else
                {
                    return HttpNotFound("Movie with such id does not exist");
                }
            }

            var votes = this.Data.Movies.All().FirstOrDefault(m => m.Id == id).Votes.Count;

            return Content(votes.ToString());
        }
    }
}