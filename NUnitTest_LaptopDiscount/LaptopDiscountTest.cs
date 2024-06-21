using System.Diagnostics;
using LaptopDiscount;

namespace LaptopDiscount
{
    public class LaptopDiscountTest
    {   
        private EmployeeDiscount _employeeDiscount {  get; set; }

        [SetUp]
        public void Setup()
        {
            _employeeDiscount = new EmployeeDiscount();
        }


        // EmployeeType
        // It is for testing whether the EmployeeType of the EmployeeDiscount would work successfully
        [Test]
        [TestCase(EmployeeType.PartTime)]
        [TestCase(EmployeeType.FullTime)]
        [TestCase(EmployeeType.CompanyPurchasing)]
        public void EmployeeTypeTest(EmployeeType emType)
        {
            //Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();   
               
            //Act
            newEmpDis.EmployeeType = emType;

            //Assert
            
            Assert.That(Equals(emType,newEmpDis.EmployeeType));
        }



        // Price
        // This is for the price attribute of the EmployeeDiscount, to check whether it would work successfully.
        [Test]
        [TestCase(100.0)]
        [TestCase(90.0)]
        [TestCase(20.0)]
        public void PriceTest(decimal price)
        {
            //Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();

            //Act
             newEmpDis.Price = price;

            //Assert

            Assert.That(Equals(price, newEmpDis.Price));
        }


          
         //Discount Test for part-time employees
        // This is for testing the discount function for parttime Employees

        [Test]
        [TestCase(70.0)]
        [TestCase(60.0)]
        [TestCase(50.0)]

        public void DiscountTestForPartTimeEmployees(decimal price){

            // Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();
            newEmpDis.Price = price;
            newEmpDis.EmployeeType = EmployeeType.PartTime;
            decimal expectedResult = price;
            //Act

            decimal result = newEmpDis.CalculateDiscountedPrice();

            //Assert

            Assert.That(Equals(expectedResult, result));
        }


        //Discount Test for patialload employees
        // This is for testing the discounfunction for patialLoad Employees

        [Test]
        [TestCase(70.0)]
        [TestCase(60.0)]
        [TestCase(50.0)]

        public void DiscountTestForPatialLoadedEmployees(decimal price)
        {

            // Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();
            newEmpDis.Price = price;
            newEmpDis.EmployeeType = EmployeeType.PartialLoad;
            decimal expectedResult = price - (price * 0.05m);
            //Act

            decimal result = newEmpDis.CalculateDiscountedPrice();

            //Assert

            Assert.That(Equals(expectedResult, result));
        }

        //Discount Test for FullTime employees
        // This is for testing the discounfunction for Fulltime Employees

        [Test]
        [TestCase(70.0)]
        [TestCase(60.0)]
        [TestCase(50.0)]

        public void DiscountTestForPatialFullTimeEmployees(decimal price)
        {

            // Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();
            newEmpDis.Price = price;
            newEmpDis.EmployeeType = EmployeeType.FullTime;
            decimal expectedResult = price - (price * 0.1m);
            //Act

            decimal result = newEmpDis.CalculateDiscountedPrice();

            //Assert

            Assert.That(Equals(expectedResult, result));
        }

        //Discount Test for CompanyPuchase employees
        // This is for testing the discounfunction for CompanyPurchase Employees

        [Test]
        [TestCase(70.0)]
        [TestCase(60.0)]
        [TestCase(50.0)]

        public void DiscountTestForCompanyPurchaseEmployees(decimal price)
        {

            // Arrange
            EmployeeDiscount newEmpDis = new EmployeeDiscount();
            newEmpDis.Price = price;
            newEmpDis.EmployeeType = EmployeeType.CompanyPurchasing;
            decimal expectedResult = price - (price * 0.2m);
            //Act

            decimal result = newEmpDis.CalculateDiscountedPrice();

            //Assert

            Assert.That(Equals(expectedResult, result));
        }

    }
}