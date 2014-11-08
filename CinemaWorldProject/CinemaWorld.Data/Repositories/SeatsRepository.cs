namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class SeatsRepository : GenericRepository<Seat>, IGenericRepository<Seat>
    {
        public SeatsRepository(DbContext context)
            : base(context)
        {
        }
    }
}