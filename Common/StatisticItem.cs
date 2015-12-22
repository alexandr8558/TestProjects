using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public struct StatisticItem
    {
        #region Constructors

        public StatisticItem(string description, int firstValue, int secondValue)
            :this()
        {
            Description = description;
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        #endregion

        #region Properties

        public string Description
        {
            get;
            private set;
        }

        public int FirstValue
        {
            get;
            private set;
        }

        public int SecondValue
        {
            get;
            private set;
        }

        #endregion
    }
}
