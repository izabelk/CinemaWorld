namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class MoviesRepository : GenericRepository<Movie>, IGenericRepository<Movie>
    {
        public MoviesRepository(DbContext context)
            : base(context)
        {
        }
    }
}