namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class ChildrensPrice : Price
    {
        public override decimal Calculate(int daysRented)
        {
            var amount = 1.5m;
            if (daysRented > 3)
            {
                amount += (daysRented - 3) * 1.5m;
            }
            return amount;
        }
    }
}
