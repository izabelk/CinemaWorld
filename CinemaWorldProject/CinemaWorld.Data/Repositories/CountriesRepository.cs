namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class CountriesRepository : GenericRepository<Country>, IGenericRepository<Country>
    {
        public CountriesRepository(DbContext context)
            : base(context)
        {
        }
    }
}