using System;
using System.IO;
using Common;

namespace Football
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
            StatisticItem result;

            parser = new Parser();
            splitter = ' ';

            result = GetTeamWithMinDifference(args[0]);

            Console.WriteLine(String.Format("{0} is the team with min difference between scored and missed goals equal {1}.",
               result.Description, result.FirstValue - result.SecondValue));
        }

        private static StatisticItem GetTeamWithMinDifference(string filePath)
        {
            StreamReader reader;
            StatisticItem currentResult;
            StatisticItem? result;

            result = null;
            using (reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    if (parser.TryParse(reader.ReadLine(), splitter, 1, 6, 8, out currentResult))
                    {
                        if (!result.HasValue || GetGoalDifference(currentResult) < GetGoalDifference(result.Value))
                        {
                            result = currentResult;
                        }
                    }
                }
            }

            return result.Value;
        }

        private static int GetGoalDifference(StatisticItem item)
        {
            return item.FirstValue - item.SecondValue;
        }

        #endregion
    }
}
