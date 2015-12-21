using System;
using System.IO;

namespace Football
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
            TeamResult result;
            
            parser = new Parser();
            splitter = ' ';

            result = GetTeamWithMinDifference(args[0]);
            
            Console.WriteLine(String.Format("{0} is the team with min difference between scored and missed goals equal {1}.",
               result.Name, result.Difference));
        }

        private static TeamResult GetTeamWithMinDifference( string filePath )
        {
            StreamReader reader;
            TeamResult currentResult;
            TeamResult? result;

            result = null;
            using ( reader = new StreamReader( filePath ) )
            {
                while (!reader.EndOfStream)
                {
                    if (parser.TryParse(reader.ReadLine(), splitter, out currentResult))
                    {
                        if (!result.HasValue || currentResult.Difference < result.Value.Difference)
                        {
                            result = currentResult;
                        }
                    }
                }
            }

            return result.Value;
        }

        #endregion
    }   
}
