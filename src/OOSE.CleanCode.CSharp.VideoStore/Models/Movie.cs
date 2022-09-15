using OOSE.CleanCode.CSharp.VideoStore.Enums;

namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Movie
    {
        public Movie(string title, PriceCode priceCode)
        {
            PriceCode = priceCode;
            Title = title;
        }

        public PriceCode PriceCode { get; set; }
        public virtual string Title { get; }
    }
}
