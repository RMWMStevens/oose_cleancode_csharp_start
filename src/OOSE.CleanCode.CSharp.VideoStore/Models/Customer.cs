using OOSE.CleanCode.CSharp.VideoStore.Enums;
using System.Globalization;

namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            var frequentRenterPoints = 0;
            var totalAmount = 0m;
            var result = "Rental Record for " + Name + "\n";

            foreach (var each in _rentals)
            {
                var thisAmount = 0m;

                // Determines the amount for each line
                switch (each.Movie.PriceCode)
                {
                    case PriceCode.Regular:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                        {
                            thisAmount += (each.DaysRented - 2) * 1.5m;
                        }
                        break;
                    case PriceCode.NewRelease:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case PriceCode.Children:
                        thisAmount += 1.5m;
                        if (each.DaysRented > 3)
                        {
                            thisAmount += (each.DaysRented - 3) * 1.5m;
                        }
                        break;
                }

                frequentRenterPoints++;

                if (each.Movie.PriceCode == PriceCode.NewRelease && each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                result += "\t" + each.Movie.Title + "\t" + thisAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += thisAmount;
            }

            result += "You owed " + totalAmount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
            result += "You earned " + frequentRenterPoints.ToString() + " frequent renter points \n";

            return result;
        }
    }
}
