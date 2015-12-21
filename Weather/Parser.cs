using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class Parser
    {
        #region Methods

        public DailyWeather Parse( string value , char splitter )
        {
            string[] parts;
            long day;
            int max;
            int min;

            parts = value.Split( new char[] { splitter } , StringSplitOptions.RemoveEmptyEntries );

            if ( Int64.TryParse( parts[ 0 ] , out day ) && Int32.TryParse( parts[ 1 ] , out min ) && Int32.TryParse( parts[ 2 ] , out max ) )
            {
                return new DailyWeather( day , min , max );
            }
            else
            {
                throw new ArgumentException( "Incoming value has wrong format." );
            }
        }

        #endregion
    }
}
