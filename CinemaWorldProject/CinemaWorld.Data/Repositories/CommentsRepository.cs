namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class CommentsRepository : GenericRepository<Comment>, IGenericRepository<Comment>
    {
        public CommentsRepository(DbContext context)
            : base(context)
        {
        }
    }
}