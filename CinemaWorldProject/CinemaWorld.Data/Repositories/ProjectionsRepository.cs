namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class ProjectionsRepository : GenericRepository<Projection>, IGenericRepository<Projection>
    {
        public ProjectionsRepository(DbContext context)
            : base(context)
        {
        }
    }
}