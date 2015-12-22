using System;
using System.IO;
using Common;

namespace Weather
{
    public class Program
    {
        #region Fieds

        private static Parser parser;

        private static char splitter;

        #endregion

        #region Methods

        public static void Main(string[] args)
        {
            StatisticItem minDifferenceWeather;

            splitter = '\t';
            parser = new Parser();

            minDifferenceWeather = GetMinDifferenceWeather(args[0]);

            Console.WriteLine(String.Format("{0} day is the day with min difference between Max and Min temperature equal {1}.",
                minDifferenceWeather.Description, minDifferenceWeather.SecondValue - minDifferenceWeather.FirstValue));
        }

        private static StatisticItem GetMinDifferenceWeather(string filePath)
        {
            StreamReader reader;
            StatisticItem? resultWeather;
            StatisticItem currentWhether;

            resultWeather = null;
            using (reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    if (parser.TryParse(reader.ReadLine(), splitter, 0, 1, 2, out currentWhether))
                    {
                        if (!resultWeather.HasValue || GetTemperatureDifference( currentWhether ) < GetTemperatureDifference( resultWeather.Value ))
                        {
                            resultWeather = currentWhether;
                        }
                    }
                }
            }
            return resultWeather.Value;
        }

        private static int GetTemperatureDifference( StatisticItem item )
        {
            return item.SecondValue - item.FirstValue;
        }

        #endregion
    }
}
