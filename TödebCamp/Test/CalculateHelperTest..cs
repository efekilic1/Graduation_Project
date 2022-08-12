using Businesss.Configuration.Helper;
using Xunit;

namespace Test
{
    public class CalculateHelperTest
    {
        [Fact]
        public void CalculateCommission_Success()
        {
            // arrange -- kullanılacak olan parametre ve servislerin hazırlanmasıdır.
            decimal price = 100;

            //act -- Servisin çağrıldığı kısımdır.
            var response = CalculatorHelper.CalculateCommission(price);

            //assert -- Sonucun karşılaştırılması.
            Assert.Equal((decimal)2, response);

        }
    }
}