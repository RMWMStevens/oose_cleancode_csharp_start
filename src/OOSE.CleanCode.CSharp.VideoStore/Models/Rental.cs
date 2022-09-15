namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Rental
    {
        public Movie Movie { get; }

        public DateTime Start { get; }

        public DateTime? End { get; }

        public int DaysRented
        {
            get => End is not null ? (End.Value - Start).Days : (DateTime.Now - Start).Days;
        }

        public Rental(Movie movie, DateTime start)
        {
            Movie = movie;
            Start = start;
        }

        public Rental(Movie movie, DateTime start, DateTime? end) : this(movie, start)
        {
            End = end;
        }
    }
}
