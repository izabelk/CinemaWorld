namespace CinemaWorld.Data.Repositories
{
    using System.Data.Entity;

    using CinemaWorld.Models;

    public class UsersRepository : GenericRepository<ApplicationUser>, IGenericRepository<ApplicationUser>
    {
        public UsersRepository(DbContext context)
            : base(context)
        {
        }
    }
}