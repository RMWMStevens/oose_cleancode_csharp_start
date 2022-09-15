using OOSE.CleanCode.CSharp.VideoStore.Enums;
using OOSE.CleanCode.CSharp.VideoStore.Models;

namespace OOSE.CleanCode.CSharp.VideoStore.Tests
{
    public class VideoStoreTests
    {
        private readonly Customer _customer;

        public VideoStoreTests()
        {
            _customer = new Customer("Fred");
        }

        [Fact]
        public void TestSingleNewReleaseStatement()
        {
            _customer.AddRental(new Rental(new Movie("The cell", PriceCode.NewRelease), 3));
            Assert.Equal("Rental Record for Fred\n\tThe cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points \n",
                         _customer.Statement());
        }

        [Fact]
        public void TestDualNewReleaseStatement()
        {
            _customer.AddRental(new Rental(new Movie("The cell", PriceCode.NewRelease), 3));
            _customer.AddRental(new Rental(new Movie("The Tigger Movie", PriceCode.NewRelease), 3));

            Assert.Equal("Rental Record for Fred\n\tThe cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points \n",
                         _customer.Statement());
        }

        [Fact]
        public void TestSingleChildrensStatement()
        {
            _customer.AddRental(new Rental(new Movie("The Tigger Movie", PriceCode.Children), 3));

            Assert.Equal("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points \n",
                _customer.Statement());
        }

        [Fact]
        public void TestMultipleRegularStatement()
        {
            _customer.AddRental(new Rental(new Movie("Plan 9 from Outer Space", PriceCode.Regular), 1));
            _customer.AddRental(new Rental(new Movie("8 1/2", PriceCode.Regular), 2));
            _customer.AddRental(new Rental(new Movie("Eraserhead", PriceCode.Regular), 3));

            Assert.Equal("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points \n",
                _customer.Statement());
        }
    }
}