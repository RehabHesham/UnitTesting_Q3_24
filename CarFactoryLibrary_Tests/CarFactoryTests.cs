using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarFactoryTests
    {
        [Fact]
        public void NewCar_AskForHonda_Exception()
        {
            // Arrange




            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? actualCar = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
