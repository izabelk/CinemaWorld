namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class CategoriesRepository : GenericRepository<Category>, IGenericRepository<Category>
    {
        public CategoriesRepository(DbContext context)
            : base(context)
        {
        }
    }
}