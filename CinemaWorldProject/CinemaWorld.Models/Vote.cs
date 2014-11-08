namespace CinemaWorld.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}