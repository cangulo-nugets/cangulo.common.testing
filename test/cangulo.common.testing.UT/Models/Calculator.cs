namespace cangulo.common.testing.dataatributes.UT.Models
{
    public interface ICalculator
    {
        int Sum(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Sum(int a, int b) => a + b;
    }
}
