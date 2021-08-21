namespace cangulo.common.testing.dataatributes.UT.Models
{
    public interface ICarService
    {
        int Create(Car car);
        Car Get(int carId);
    }
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public Car Get(int carId) => _repository.Get(carId);

        public int Create(Car car)
        {
            var dbCar = _repository.Get(car.CarId);
            if (dbCar != null)
            {
                return _repository.Create(car);
            }

            return 0;
        }
    }
}
