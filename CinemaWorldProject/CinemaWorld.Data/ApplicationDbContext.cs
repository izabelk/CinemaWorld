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

        public virtual IDbSet<Category> Gategories { get; set; }

        public virtual IDbSet<Cinema> Cinemas { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Hall> Halls { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<News> News { get; set; }

        public virtual IDbSet<Projection> Projections { get; set; }

        public virtual IDbSet<Seat> Seats { get; set; }

        public virtual IDbSet<Ticket> Tickets { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hall>().HasRequired(h => h.Cinema).WithMany().WillCascadeOnDelete(false);
        }
    }
}