using System;
using System.IO;

namespace Weather
{
    class Program
    {
        #region Fieds

        private static Parser parser;

        private static char splitter;

        #endregion

        #region Methods

        static void Main( string[] args )
        {
            DailyWeather minDifferenceWeather;

            splitter = '\t';            
            parser = new Parser();

            minDifferenceWeather = GetMinDifferenceWeather( args[ 0 ] );

            Console.WriteLine(String.Format("{0} day is the day with min difference between Max and Min temperature equal {1}.", 
                minDifferenceWeather.Day, minDifferenceWeather.Difference));
        }

        private static DailyWeather GetMinDifferenceWeather( string filePath )
        {
            StreamReader reader;
            DailyWeather resultWeather;
            DailyWeather currentWhether;

            using (reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                resultWeather = parser.Parse(reader.ReadLine(), splitter);

                while (!reader.EndOfStream)
                {
                    currentWhether = parser.Parse(reader.ReadLine(), splitter);

                    if (currentWhether.Difference < resultWeather.Difference)
                    {
                        resultWeather = currentWhether;
                    }
                }                
            }
            return resultWeather;
        }

        #endregion
    }
}
