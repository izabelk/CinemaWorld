namespace CinemaWorld.Data.UnitOfWork
{
    using CinemaWorld.Data.Repositories;

    public interface ICinemaWorldData
    {
        CategoriesRepository Categories { get; }

        CinemasRepository Cinemas { get; }

        CitiesRepository Cities { get; }

        CommentsRepository Comments { get; }

        CountriesRepository Countries { get; }

        GenresRepository Genres { get; }

        HallsRepository Halls { get; }

        MoviesRepository Movies { get; }

        NewsRepository News { get; }

        ProjectionsRepository Projections { get; }

        SeatsRepository Seats { get; }

        TicketsRepository Tickets { get; }

        VotesRepository Votes { get; }

        UsersRepository Users { get; }

        void SaveChanges();
    }
}