using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramRunner
{
    class Program
    {
        #region Constants

        private const string FOOTBALLSTAT = "football";

        private const string WEATHERSTAT = "weather";

        #endregion

        #region Methods

        /// <summary>
        /// Runs app according to given params.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// args[ 0 ] - program identifier to start( football to run Football app , weather - Weather app).
        /// args[ 1 ] - path to file with data.
        static void Main(string[] args)
        {
            if ( args.Length < 2 )
            {
                Console.WriteLine("Wrong parameters. Please set { App name (weather or football) } { Path to file with data }");
                return;
            }

            switch( args[ 0 ] )
            {
                case FOOTBALLSTAT:
                    Football.Program.Main(new string[] { args[1] });
                    break;

                case WEATHERSTAT:
                    Weather.Program.Main(new string[] { args[1] });
                    break;

                default:
                    Console.WriteLine( string.Format( "Unknown app name. Should be {0} or {1} " , FOOTBALLSTAT , WEATHERSTAT ));
                    break;
            }
        }

        #endregion
    }
}
