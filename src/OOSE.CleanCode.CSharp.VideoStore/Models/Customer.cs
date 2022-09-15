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
            var statement = $"Rental Record for {Name}\n";

            foreach (var rental in _rentals)
            {
                var amount = rental.Movie.Price.Calculate(rental.DaysRented);

                statement += "\t" + rental.Movie.Title + "\t" + amount.ToString("0.0", CultureInfo.InvariantCulture) + "\n";
                totalAmount += amount;
            }

            statement += $"You owed {totalAmount.ToString("0.0", CultureInfo.InvariantCulture)}\n";
            statement += $"You earned {CalculateFrequentRenterPoints(_rentals)} frequent renter points \n";

            return statement;
        }

        private int CalculateFrequentRenterPoints(List<Rental> rentals)
        {
            var frequentRenterPoints = 0;
            foreach (var rental in rentals)
            {
                frequentRenterPoints++;

                if (rental.Movie.Price is NewReleasePrice && rental.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }
            }

            return frequentRenterPoints;
        }
    }
}
