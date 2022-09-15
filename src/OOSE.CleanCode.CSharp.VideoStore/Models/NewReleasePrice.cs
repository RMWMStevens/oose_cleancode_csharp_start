namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class NewReleasePrice : Price
    {
        public override decimal Calculate(int daysRented) => daysRented * 3;
    }
}
