namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class TicketsRepository : GenericRepository<Ticket>, IGenericRepository<Ticket>
    {
        public TicketsRepository(DbContext context)
            : base(context)
        {
        }
    }
}