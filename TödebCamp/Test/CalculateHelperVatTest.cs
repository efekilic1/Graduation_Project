using Business.Configuration.Helper;
using FluentAssertions;
using Xunit;

namespace Test
{
    public class CalculatorHelperVatTest
    {
        [Theory]
        [InlineData(100, 8)] // Price 100, rate 8
        [InlineData(100, 18)] // Price 100, rate 18
        [InlineData(50, 10)] // Price 100, rate 10

        // 3 senaryo için de arka arkaya çalışır

        public void CalculatorVat_Success(decimal price, float rate)
        {

            //act
            var calculator = new CalculatorHelperVat();
            var response = calculator.CalculateVAT(price, rate);

            var actual = (price * (decimal)rate) / 100;

            //assert
  

            response.Should().BePositive(); // Builder deseni
            response.Should().Be(actual);
        }
    }
}