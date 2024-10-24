using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarStoreTests
    {
        [Fact]
        public void AddCar_NewToyota_Exist()
        {
            // Arrange
            CarStore carStore = new CarStore()
            {
                cars = [
                    new Toyota() { velocity = 5 , drivingMode = DrivingMode.Forward},
                    new BMW() { velocity = 20 , drivingMode = DrivingMode.Backward},
                    new Toyota() { velocity = 80 , drivingMode = DrivingMode.Forward},
                ]
            };

            BMW bMW = new BMW() {velocity = 0, drivingMode = DrivingMode.Stopped };
            BMW bMW2 = new BMW() {velocity = 5, drivingMode = DrivingMode.Forward };
            BMW bMW3 = new BMW() {velocity = 10, drivingMode = DrivingMode.Forward };

            // Act
            carStore.AddCar(bMW);

            // Assert
            Assert.NotEmpty(carStore.cars);
            Assert.Contains(bMW, carStore.cars);
            Assert.Contains(bMW2, carStore.cars);
            Assert.DoesNotContain(bMW3, carStore.cars);

        }
    }
}
