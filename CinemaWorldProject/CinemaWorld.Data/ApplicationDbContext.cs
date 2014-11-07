namespace CinemaWorld.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using CinemaWorld.Data.Migrations;
    using CinemaWorld.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}