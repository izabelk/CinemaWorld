namespace CinemaWorld.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using CinemaWorld.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var rand = new Random();

            if (!context.Countries.Any())
            {
                context.Countries.AddOrUpdate(
                    new Country { Name = "USA" },
                    new Country { Name = "France" },
                    new Country { Name = "Italy" },
                    new Country { Name = "Russia" },
                    new Country { Name = "German" },
                    new Country { Name = "Bulgaria" });

                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                context.Cities.AddOrUpdate(
                    new City { Name = "Sofia", CountryId = 6 },
                    new City { Name = "Pleven", CountryId = 6 },
                    new City { Name = "Ruse", CountryId = 6 },
                    new City { Name = "Varna", CountryId = 6 },
                    new City { Name = "Burgas", CountryId = 6 },
                    new City { Name = "Plovdiv", CountryId = 6 });

                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                context.Genres.AddOrUpdate(
                    new Genre { Name = "Action" },
                    new Genre { Name = "Animation" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Fantasy" });

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(
                    new Category { Name = "A" },
                    new Category { Name = "B" },
                    new Category { Name = "C" },
                    new Category { Name = "D" });

               context.SaveChanges();

            }

            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var roleResult = roleManager.Create(new IdentityRole("Admin"));

                var user = new ApplicationUser() { UserName = "admin@abv.bg", Email = "admin@abv.bg" };
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var result = userManager.Create(user, "adminpass");
                userManager.AddToRole(user.Id, "Admin");

                context.SaveChanges();
            }

            if (!context.Cinemas.Any())
            {
                context.Cinemas.AddOrUpdate(
                    new Cinema { Name = "Cinema City", CityId = 1 },
                    new Cinema { Name = "Cine Grand", CityId = 1 },
                    new Cinema { Name = "Arena Zapad", CityId = 1 },
                    new Cinema { Name = "Cinema Mladost", CityId = 1 });

                context.SaveChanges();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddOrUpdate(
                    new Movie { Title = "Fury", Description = "April, 1945. As the Allies make their final push in the European Theatre, a battle-hardened army sergeant named Wardaddy commands a Sherman tank and his five-man crew on a deadly mission behind enemy lines. Out-numbered, out-gunned, and with a rookie soldier thrust into their platoon, Wardaddy and his men face overwhelming odds in their heroic attempts to strike at the heart of Nazi Germany.", Year = 2014, Duration = 135, Director = "David Ayer", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjA4MDU0NTUyN15BMl5BanBnXkFtZTgwMzQxMzY4MjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 2, IsPremiere = true },
                    new Movie { Title = "The Maze Runner", Description = "Thomas is deposited in a community of boys after his memory is erased, soon learning they're all trapped in a maze that will require him to join forces with fellow runners for a shot at escape.", Year = 2014, Duration = 113, Director = "Wes Ball", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjUyNTA3MTAyM15BMl5BanBnXkFtZTgwOTEyMTkyMjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 2, IsPremiere = true },
                    new Movie { Title = "Gone girl", Description = "With his wife's disappearance having become the focus of an intense media circus, a man sees the spotlight turned on him when it's suspected that he may not be innocent.", Year = 2014, Duration = 149, Director = " David Fincher", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTk0MDQ3MzAzOV5BMl5BanBnXkFtZTgwNzU1NzE3MjE@._V1_SY317_CR0,0,214,317_AL_.jpg", CountryId = 1, CategoryId = 3 },
                    new Movie { Title = "Dracula Untold", Description = "As his kingdom is being threatened by the Turks, young prince Vlad Tepes must become a monster feared by his own kingdom in order to obtain the power needed to protect his own family, and the families of his kingdom.", Year = 2014, Duration = 92, Director = " Gary Shore", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMTkzNzI1OTI4N15BMl5BanBnXkFtZTgwNTQ2NzEwMjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 3 },
                    new Movie { Title = "Annabelle", Description = "A couple begins to experience terrifying supernatural occurrences involving a vintage doll shortly after their home is invaded by satanic cultists.", Year = 2014, Duration = 99, Director = " John R. Leonetti", ImageUrl = "http://ia.media-imdb.com/images/M/MV5BMjM2MTYyMzk1OV5BMl5BanBnXkFtZTgwNDg2MjMyMjE@._V1_SX214_AL_.jpg", CountryId = 1, CategoryId = 4, IsPremiere = true });

                context.SaveChanges();
            }

            if (!context.News.Any())
            {
                context.News.AddOrUpdate(
                    new News { Content = "Oscar winner Jared Leto is circling a key role in David Ayer‘s “Suicide Squad” that could prove to be The Joker, an individual familiar with the Warner Bros. project has told TheWrap. Warner Bros. had no comment, while a representative for Leto did not immediately respond to a request for comment. Tom Hardy, Will Smith and Margot Robbie are in various stages of discussions to star in “Suicide Squad,” which David Ayer is directing and Charles Roven is producing. Jesse Eisenberg is also expected to reprise his role as Superman's mortal foe Lex Luthor, though no casting is confirmed at this time.", CreatedOn = DateTime.Now },
                    new News { Content = "Amanda Bynes needed a change, so she made a big one. The former child star revealed that she opted to add more color to her usual blond tresses, and switched up her 'do with a purple hue! Bynes stepped out with her new lavender locks today, debuting the finished look after letting her Twitter followers know earlier in the day that she was at the hair salon for a dye job. I dyed my hair violet :D I'm not sure if I like it , and this is a blurry pic but here it is ! We like it! Although the change in color is an interesting move, what seems more puzzling is the fact that Bynes just said she didnt have enough money for a hotel, but apparently had enough dollars for a pricey ", CreatedOn = DateTime.Now },
                    new News { Content = "Here's yet another reason why Tig Notaro is a woman who can't help but blaze a trail of inspiration (and laughter, of course) wherever she goes. As detailed on The New Yorker's website today, the comedian—who broke through in a big way when she revealed during a stand-up set in 2012 that she had breast cancer and proceeded to bring the house down—responded to a catcall-type whoop from an audience member at her show in NYC last night by ripping open her shirt, scars from a double mastectomy fully visible, and continuing to perform topless for 20 minutes. Performing at The Town Hall, a stop on her Boyish Girl Interrupted Tour, Notaro was telling a bit about getting a pat-down at the airport and ", CreatedOn = DateTime.Now });

                context.SaveChanges();
            }

            if (!context.Halls.Any())
            {
                for (int i = 0; i < context.Cinemas.Count(); i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        context.Halls.AddOrUpdate(
                            new Hall { Number = j + 1, CinemaId = i + 1 });
                    }
                }

                context.SaveChanges();
            }

            if (!context.Projections.Any())
            {

                for (int i = 0; i < 20; i++)
                {
                    var randomDate = DateTime.Now.AddDays(rand.Next(1, 10));
                    randomDate = randomDate.AddHours(rand.Next(-5, 5));

                    context.Projections.AddOrUpdate(
                        new Projection { MovieId = rand.Next(1, 6), HallId = rand.Next(1, 120), ShownOn = randomDate });
                }
            }

            if (!context.Seats.Any())
            {
                for (int i = 0; i < context.Projections.Count(); i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        context.Seats.AddOrUpdate(
                    new Seat { Number = j + 1, ProjectionId = i + 1 });
                    }
                }
            }
        }
    }
}