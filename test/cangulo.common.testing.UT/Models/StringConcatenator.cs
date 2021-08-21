namespace cangulo.common.testing.dataatributes.UT.Models
{
    public interface IStringConcatenator
    {
        string Concatenate(string a, string b);
    }
    public class StringConcatenator : IStringConcatenator
    {
        public string Concatenate(string a, string b) => a + b;
    }
}
