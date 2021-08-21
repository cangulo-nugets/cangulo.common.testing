using AutoFixture.Xunit2;
using cangulo.common.testing.dataatributes.UT.Models;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace cangulo.common.testing.dataatributes.UT
{
    public class AutoNSubstituteDataAttributeTestsForComplexTypes
    {
        [Theory]
        [AutoNSubstituteData]
        public void InjectInterface(ICarService carService, int carId)
        {

            // Arrange
            var expectedCar = CarsContants.OnlyCarAvailable;
            carService.Get(carId).Returns(expectedCar);

            var sut = new CarController(carService);

            // Act
            var result = sut.GetCar(carId);

            // Assert
            result.Should().Be(expectedCar);
            carService.Received(1).Get(carId);
        }

        [Theory]
        [AutoNSubstituteData]
        public void InjectEntityClass(ICarService carService, Car expectedCar)
        {

            // Arrange
            carService.Get(expectedCar.CarId).Returns(expectedCar);

            var sut = new CarController(carService);

            // Act
            var result = sut.GetCar(expectedCar.CarId);

            // Assert
            result.Should().Be(expectedCar);
            carService.Received(1).Get(expectedCar.CarId);
        }

        [Theory]
        [AutoNSubstituteData]
        public void InjectClassAndInteface(
            [Frozen] ICarService carService,
            Car expectedCar,
            CarController sut)
        {

            // Arrange
            carService.Get(expectedCar.CarId).Returns(expectedCar);

            // Act
            var result = sut.GetCar(expectedCar.CarId);

            // Assert
            result.Should().Be(expectedCar);
            carService.Received(1).Get(expectedCar.CarId);
        }
    }
}
