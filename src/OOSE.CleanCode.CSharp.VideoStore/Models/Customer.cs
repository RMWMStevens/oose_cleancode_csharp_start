using OOSE.CleanCode.CSharp.VideoStore.Enums;
using System.Globalization;

namespace OOSE.CleanCode.CSharp.VideoStore.Models
{
    public class Customer
    {
        public string Name { get; }

        private readonly List<Rental> _rentals = new();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string GenerateStatement()
        {
            var totalAmount = 0m;
            var statement = "Rental Record for " + Name + "\n";

            foreach (var rental in _rentals)
            {
                var amount = 0m;

                // Determines the amount for each line
                switch (rental.Movie.PriceCode)
                {
                    case PriceCode.Regular:
                        amount += 2;
                        if (rental.DaysRented > 2)
                        {
                            amount += (rental.DaysRented - 2) * 1.5m;
                        }
                        break;
                    case PriceCode.NewRelease:
                        amount += rental.DaysRented * 3;
                        break;
                    case PriceCode.Children:
                        amount += 1.5m;
                        if (rental.DaysRented > 3)
                        {
                            amount += (rental.DaysRented - 3) * 1.5m;
                        }
                        break;
                }

                statement += "\t" + rental.Movie.Title + "\t" + amount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += amount;
            }

            var frequentRenterPoints = 0;
            foreach (var rental in _rentals)
            {
                frequentRenterPoints++;

                if (rental.Movie.PriceCode == PriceCode.NewRelease && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }

            statement += $"You owed {totalAmount.ToString("0.0", CultureInfo.InvariantCulture)}\n";
            statement += $"You earned {frequentRenterPoints} frequent renter points \n";

            return statement;
        }
    }
}
