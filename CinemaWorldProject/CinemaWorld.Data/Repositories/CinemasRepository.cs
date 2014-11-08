namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class CinemasRepository : GenericRepository<Cinema>, IGenericRepository<Cinema>
    {
        public CinemasRepository(DbContext context)
            : base(context)
        {
        }
    }
}