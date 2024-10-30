using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_Tests
{
    public  class TestRepoTests
    {
    Mock<FactoryContext> mock;
    TestRepo testRepo;

        public TestRepoTests()
        {
            // test setup
             mock = new Mock<FactoryContext>();

            


            testRepo  = new(mock.Object);
        }
        [Fact]
        public void GetAll_TryToGetData_ReturnListOfCars()
        {
            //Arrange

            // Create Fake mock Data
            Car car = new Car() { Id = 2 };
            List<Car> cars = new()
            {
                new Car(){Id = 1},
                car,
            };

            // Setup mock Functions
            mock.Setup(o => o.Cars).ReturnsDbSet(cars);

            // Act

            List<Car> result = testRepo.GetAll();
            // Assert
            Assert.Contains<Car>(car, result);
        }
    }
}
