namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public abstract class Price
    {
        public abstract decimal Calculate(int daysRented);
    }
}