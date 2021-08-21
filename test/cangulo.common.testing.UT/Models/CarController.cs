using System;

namespace cangulo.common.testing.dataatributes.UT.Models
{
    public class CarController
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        public Car GetCar(int id) => _carService.Get(id);
        public int CreateCar(Car car) => _carService.Create(car);
    }
}
