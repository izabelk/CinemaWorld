namespace CinemaWorld.Data.UnitOfWork
{
    using CinemaWorld.Data.Repositories;

    public interface ICinemaWorldData
    {
        UsersRepository Users { get; }

        void SaveChanges();
    }
}