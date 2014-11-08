namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class NewsRepository : GenericRepository<News>, IGenericRepository<News>
    {
        public NewsRepository(DbContext context)
            : base(context)
        {
        }
    }
}