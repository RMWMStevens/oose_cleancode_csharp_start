namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class RegularPrice : Price
    {
        public override decimal Calculate(int daysRented)
        {
            var amount = 2m;
            if (daysRented > 2)
            {
                amount += (daysRented - 2) * 1.5m;
            }
            return amount;
        }
    }
}
