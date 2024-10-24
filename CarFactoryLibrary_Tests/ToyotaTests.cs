using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    // Testing class must be puplic in xunit
    public class ToyotaTests
    {
        // Testing Method must have one of the two attributes
        // [Fact]   => if test methods have no parameters
        // [Theory] => if test methods have parameters
        // must be public
        // return no value
        // naming Conventional: [MethodName]_[caseUnderTest]_[ExpectedBehavior]


        [Fact]
        public void IsStopped_Velocity0_True()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 0;

            // Act
            bool actualResult = toyota.IsStopped();

            // Assert
            Assert.True(actualResult);

        }

        [Fact]
        public void GetDirection_ForwardDirection_Forward()
        {
            // Arrange
            Toyota toyota = new() { drivingMode = DrivingMode.Forward };

            // Act
            string actualResult = toyota.GetDirection();

            // Assert
            Assert.Equal("Forward", actualResult);
            Assert.Equal("forward", actualResult,ignoreCase: true);
            Assert.Contains("war", actualResult);
            Assert.StartsWith("For", actualResult);
            Assert.StartsWith("for", actualResult, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith("ard", actualResult);


            Assert.Matches("^F[a-z]{6}", actualResult);
            Assert.DoesNotMatch("^F[a-z]{8}", actualResult);
        }

        [Fact]
        public void GetMyCar_CompareWithBMW_Equals()
        {
            // Arrange
            Toyota toyota = new() {velocity = 10, drivingMode = DrivingMode.Forward };
            BMW bMW = new() { velocity = 10, drivingMode = DrivingMode.Forward };

            // Act
            Car ActualResult = toyota.GetMyCar();

            // Assert
            Assert.Equal<Car>(bMW, ActualResult);

            Assert.NotNull(ActualResult);
            Assert.Same(toyota, ActualResult);


            Assert.IsType<Toyota>(ActualResult);

            Assert.IsAssignableFrom<Car>(bMW);
        }

        [Fact]
        public void TimeToCoverDistance_Velocity5Distance10_time2()
        {
            // Arrange
            Toyota toyota = new() { velocity = 5 };

            // Act
            double actualResult = toyota.TimeToCoverDistance(10);

            // Assert
            Assert.Equal(2, actualResult);

            Assert.InRange(actualResult, 1, 3);
        }
    }
}
