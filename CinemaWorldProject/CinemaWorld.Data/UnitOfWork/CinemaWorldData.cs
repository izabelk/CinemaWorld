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
        private IDictionary<System.Type, object> repositories;

        public CinemaWorldData(ApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<System.Type, object>();
        }

        public UsersRepository Users
        {
            get
            {
                return (UsersRepository)this.GetRepository<ApplicationUser>();
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

                //if (typeOfModel.IsAssignableFrom(typeof(JobPost)))
                //{
                //    type = typeof(JobPostsRepository);
                //}
                //else if (typeOfModel.IsAssignableFrom(typeof(ApplicationUser)))
                //{
                //    type = typeof(UsersRepository);
                //}
                //else if (typeOfModel.IsAssignableFrom(typeof(City)))
                //{
                //    type = typeof(CitiesRepository);
                //}
                //else if (typeOfModel.IsAssignableFrom(typeof(Category)))
                //{
                //    type = typeof(CategoriesRepository);
                //}
                //else if (typeOfModel.IsAssignableFrom(typeof(JobApplication)))
                //{
                //    type = typeof(JobApplicationsRepository);
                //}

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}