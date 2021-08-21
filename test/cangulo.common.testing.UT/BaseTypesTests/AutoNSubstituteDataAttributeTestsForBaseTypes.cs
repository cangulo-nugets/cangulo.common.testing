using cangulo.common.testing.dataatributes.UT.Models;
using FluentAssertions;
using Xunit;

namespace cangulo.common.testing.dataatributes.UT
{
    public class AutoNSubstituteDataAttributeTestsForBaseTypes
    {
        private readonly ICalculator _calculator;
        private readonly IStringConcatenator _stringConcatenator;

        public AutoNSubstituteDataAttributeTestsForBaseTypes()
        {
            _calculator = new Calculator();
            _stringConcatenator = new StringConcatenator();
        }

        [Theory]
        [AutoNSubstituteData]
        public void InjectAllValues_For_IntType(int a, int b)
        {

            // Arrange
            var expectedResult = a + b;
            
            // Act
            var result = _calculator.Sum(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [AutoNSubstituteData]
        public void InjectAllValues_For_Strings(string a, string b)
        {

            // Arrange
            var expectedResult = a + b;

            // Act
            var result = _stringConcatenator.Concatenate(a, b);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
