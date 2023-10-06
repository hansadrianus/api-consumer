using ApplicationUI.Utilities;
using System;
using Xunit;

namespace UnitTest
{
    public class TemperatureUtilityUnitTest
    {
        [Fact]
        public void MayConvertToCelcius()
        {
            double input = 32;
            double result = TemperatureUtility.ConvertTemperatureToCelcius(input);

            Assert.Equal(0, result);
        }
    }
}
