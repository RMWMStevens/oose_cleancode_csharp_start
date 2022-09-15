using OOSE.CleanCode.CSharp.VideoStore.Enums;

namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Movie
    {
        public string Title { get; }

        public PriceCode PriceCode { get; set; }

        public Movie(string title, PriceCode priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
    }
}
