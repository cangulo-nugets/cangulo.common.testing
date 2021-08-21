namespace cangulo.common.testing.dataatributes.UT.Models
{
    public interface ICarRepository
    {
        Car Get(int Id);
        int Create(Car car);
    }

    public class CarRepository : ICarRepository
    {
        public Car Get(int Id) => CarsContants.OnlyCarAvailable;
        public int Create(Car car) => 1;
    }
}
