namespace CinemaWorld.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;

    using CinemaWorld.Data.Repositories;
    using CinemaWorld.Models;

    public class CinemaWorldData : ICinemaWorldData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public CinemaWorldData(ApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public UsersRepository Users
        {
            get
            {
                return (UsersRepository)this.GetRepository<ApplicationUser>();
            }
        }

        public CategoriesRepository Categories
        {
            get
            {
                return (CategoriesRepository)this.GetRepository<Category>();
            }
        }

        public CitiesRepository Cities
        {
            get
            {
                return (CitiesRepository)this.GetRepository<City>();
            }
        }

        public CinemasRepository Cinemas
        {
            get
            {
                return (CinemasRepository)this.GetRepository<Cinema>();
            }
        }

        public CommentsRepository Comments
        {
            get
            {
                return (CommentsRepository)this.GetRepository<Comment>();
            }
        }

        public CountriesRepository Countries
        {
            get
            {
                return (CountriesRepository)this.GetRepository<Country>();
            }
        }

        public GenresRepository Genres
        {
            get
            {
                return (GenresRepository)this.GetRepository<Genre>();
            }
        }

        public HallsRepository Halls
        {
            get
            {
                return (HallsRepository)this.GetRepository<Hall>();
            }
        }

        public MoviesRepository Movies
        {
            get
            {
                return (MoviesRepository)this.GetRepository<Movie>();
            }
        }

        public NewsRepository News
        {
            get
            {
                return (NewsRepository)this.GetRepository<News>();
            }
        }

        public ProjectionsRepository Projections
        {
            get
            {
                return (ProjectionsRepository)this.GetRepository<Projection>();
            }
        }

        public SeatsRepository Seats
        {
            get
            {
                return (SeatsRepository)this.GetRepository<Seat>();
            }
        }

        public TicketsRepository Tickets
        {
            get
            {
                return (TicketsRepository)this.GetRepository<Ticket>();
            }
        }

        public VotesRepository Votes
        {
            get
            {
                return (VotesRepository)this.GetRepository<Vote>();
            }
        }

        public void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Category)))
                {
                    type = typeof(CategoriesRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(ApplicationUser)))
                {
                    type = typeof(UsersRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(City)))
                {
                    type = typeof(CitiesRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Cinema)))
                {
                    type = typeof(CinemasRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Comment)))
                {
                    type = typeof(CommentsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Country)))
                {
                    type = typeof(CountriesRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Genre)))
                {
                    type = typeof(GenresRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Hall)))
                {
                    type = typeof(HallsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Movie)))
                {
                    type = typeof(MoviesRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(News)))
                {
                    type = typeof(NewsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Projection)))
                {
                    type = typeof(ProjectionsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Seat)))
                {
                    type = typeof(SeatsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Ticket)))
                {
                    type = typeof(TicketsRepository);
                }
                else if (typeOfModel.IsAssignableFrom(typeof(Vote)))
                {
                    type = typeof(VotesRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}