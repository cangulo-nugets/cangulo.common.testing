# cangulo.common.testing

## Goals

Main Goal:
* Provide common attributes and methods to xunit tests

# How to use cangulo.common.testing

## Injecting and configuring a Interface that is used in a constructor

```csharp
[Theory]
[AutoNSubstituteData]
public void InjectInterface(ICarService carService, int carId)
{

    // Arrange
    var expectedCar = CarsContants.OnlyCarAvailable;
    
    // Setting the interface behaviour
    carService.Get(carId).Returns(expectedCar);

    // Using the interface injected
    var sut = new CarController(carService);

    // Act
    var result = sut.GetCar(carId);

    // Assert
    result.Should().Be(expectedCar);
    carService.Received(1).Get(carId);
}
```

## Injecting a complex object
```csharp
[Theory]
[AutoNSubstituteData]
public void InjectEntityClass(ICarService carService, Car expectedCar)
{

    // Arrange
    // using the complex object expectedCar
    carService.Get(expectedCar.CarId).Returns(expectedCar);

    var sut = new CarController(carService);

    // Act
    var result = sut.GetCar(expectedCar.CarId);

    // Assert
    result.Should().Be(expectedCar);
    carService.Received(1).Get(expectedCar.CarId);
}
```

## Injecting the target class (subject under test) and provide the services (interfaces)
```csharp
[Theory]
[AutoNSubstituteData]
public void InjectClassAndInteface(
    [Frozen] ICarService carService,    // service
    Car expectedCar,
    CarController sut)  // target class (subject under test)
{

    // Arrange
    carService.Get(expectedCar.CarId).Returns(expectedCar);

    // Act
    var result = sut.GetCar(expectedCar.CarId);

    // Assert
    result.Should().Be(expectedCar);
    carService.Received(1).Get(expectedCar.CarId);
}
```

# Inspired by:

* https://stackoverflow.com/questions/38088639/use-autodata-and-memberdata-attributes-in-xunit-test
* https://blog.nikosbaxevanis.com/2012/07/27/composite-xunit-net-data-attributes/ 
* https://blog.nikosbaxevanis.com/2012/07/31/autofixture-xunit-net-and-auto-mocking/
* https://seanspaniel.wordpress.com/2018/09/30/tutorial-getting-started-with-xunit-and-autofixture/
* https://chlee.co/how-to-save-time-writing-unit-and-integration-tests-with-autofixture/