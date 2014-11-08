namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class GenresRepository : GenericRepository<Genre>, IGenericRepository<Genre>
    {
        public GenresRepository(DbContext context)
            : base(context)
        {
        }
    }
}