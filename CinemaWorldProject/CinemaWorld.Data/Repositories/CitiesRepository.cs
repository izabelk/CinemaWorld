namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class CitiesRepository : GenericRepository<City>, IGenericRepository<City>
    {
        public CitiesRepository(DbContext context)
            : base(context)
        {
        }
    }
}