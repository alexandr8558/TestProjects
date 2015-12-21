using System;

namespace Weather
{
    public struct DailyWeather
    {
        #region Constructors

        public DailyWeather( long day , int min , int max )
            :this()
        {
            Day = day;
            Max = max;
            Min = min;
        }

        #endregion

        #region Properties

        public long Day
        {
            get;
            private set;
        }

        public int Max
        {
            get;
            private set;
        }

        public int Min
        {
            get;
            private set;
        }

        public int Difference
        {
            get
            {
                return Max - Min;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return String.Format( "Day: {0}, Min: {1}, Max: {2}, Difference: {3}" , Day , Min , Max , Difference );
        }

        #endregion
    }
}
