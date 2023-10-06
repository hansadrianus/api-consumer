using System;

namespace ApplicationUI.Utilities
{
    public static class TemperatureUtility
    {
        public static double ConvertTemperatureToCelcius(double temperature)
        {
            const double FAHRENHEIT = 32;

            return Math.Round(((temperature - FAHRENHEIT) * 5 / 9), 2);
        }
    }
}
