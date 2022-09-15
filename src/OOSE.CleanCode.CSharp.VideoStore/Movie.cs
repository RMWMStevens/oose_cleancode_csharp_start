namespace OOSE.CleanCode.CSharp.VideoStore
{
    public class Movie
    {
        public Movie(string title, int priceCode)
        {
            PriceCode = priceCode;
            Title = title;
        }

        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN = 2;

        public int PriceCode { get; set; }
        public virtual string Title { get; }
    }
}
