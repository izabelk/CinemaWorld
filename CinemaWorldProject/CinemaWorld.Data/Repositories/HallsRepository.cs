namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class HallsRepository : GenericRepository<Hall>, IGenericRepository<Hall>
    {
        public HallsRepository(DbContext context)
            : base(context)
        {
        }
    }
}