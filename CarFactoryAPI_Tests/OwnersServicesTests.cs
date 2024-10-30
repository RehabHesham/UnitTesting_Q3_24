using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryAPI_Tests
{
    public class OwnersServicesTests : IDisposable
    {
        private readonly ITestOutputHelper outputHelper;
        // Create mock for dependencies
        Mock<ICarsRepository> carRepoMock;
        Mock<IOwnersRepository> ownerRepoMock;
        Mock<ICashService> cashServiceMock;
        // use fake object as dependency
        OwnersService ownersService;
        public OwnersServicesTests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
            // Test Setup
            outputHelper.WriteLine("Test Setup");

            // Create mock for dependencies
            carRepoMock = new();
            ownerRepoMock = new();
            cashServiceMock = new();
            // use fake object as dependency
            ownersService = new(carRepoMock.Object, ownerRepoMock.Object, cashServiceMock.Object);
        }
        public void Dispose()
        {
            // Test Clean up
            outputHelper.WriteLine("Test Clean up");

        }
        [Fact]
        public void BuyCar_BuyInvalidCar_notExist()
        {
            // Arrange
            IInMemoryContext context = new InMemoryContext();

            ICarsRepository carsRepository = new CarsRepository(context);
            IOwnersRepository ownersRepository = new OwnersRepository(context);
            ICashService cashService = new CashService();

            OwnersService ownersService = new(carsRepository,ownersRepository,cashService);

            BuyCarInput carInput = new BuyCarInput()
            {
                CarId = 10,
                OwnerId = 10,
                Amount = 1000
            };

            // Act
            string actualResult = ownersService.BuyCar(carInput);

            // Assert
            Assert.Contains("exist", actualResult);

        }


        [Fact]
        public void BuyCar_BuySoldCar_AlreadySold()
        {
            outputHelper.WriteLine("Test 1");

            // Arrange

            // prepare test case data
            Car car = new Car() {Id = 1, Price=1000, Type=CarType.BMW, Velocity=50, OwnerId=2, Owner= new Owner() };

            // Setup mock object Methods
            carRepoMock.Setup(o=>o.GetCarById(1)).Returns(car);

            BuyCarInput carInput = new BuyCarInput()
            {
                CarId = 1,
                OwnerId = 12,
                Amount = 1000
            };

            // Act
            string ActualOutput = ownersService.BuyCar(carInput);


            // Assert
            Assert.Equal("Already sold", ActualOutput);
        }

        [Fact]
        public void BuyCar_OwnerNotFound_notExist()
        {
            outputHelper.WriteLine("Test 2");

            // Arrange

            //// create mock for dependencies
            //Mock<ICarsRepository> carRepoMock = new();
            //Mock<IOwnersRepository> ownerRepoMock = new();
            //Mock<ICashService> cashServiceMock = new();

            // prepare fake Mock Data
            Car car = new Car() { Id = 3, Price = 1000, Velocity = 500, Type = CarType.Audi };
            Owner owner = null;

            // Setup  Mock Functions
            carRepoMock.Setup(o=>o.GetCarById(3)).Returns(car);
            ownerRepoMock.Setup(o=>o.GetOwnerById(10)).Returns(owner);

            // use Fake object as dependency
            //OwnersService ownersService = new(carRepoMock.Object,OwnerRepoMock.Object, cashServiceMock.Object);


            BuyCarInput buyCarInput = new()
            {
                CarId = 3,
                OwnerId = 10,
                Amount = 1000
            };

            // Act
            string ActualResult = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Contains("exist", ActualResult);
        }

        
    }
}
