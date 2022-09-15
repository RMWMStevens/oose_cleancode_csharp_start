namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Movie
    {
        public string Title { get; }

        public Price Price { get; set; }

        public Movie(string title, Price price)
        {
            Title = title;
            Price = price;
        }
    }
}
