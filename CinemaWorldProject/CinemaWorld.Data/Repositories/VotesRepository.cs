namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class VotesRepository : GenericRepository<Vote>, IGenericRepository<Vote>
    {
        public VotesRepository(DbContext context)
            : base(context)
        {
        }
    }
}