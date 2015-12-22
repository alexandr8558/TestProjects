using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Parser
    {
        #region Methods

        public bool TryParse(string value, char splitter, byte descriptionPos, byte firstValuePos, byte secondValuePos, out StatisticItem result)
        {
            string[] parts;
            int firstValue;
            int secondValue;

            parts = value.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > secondValuePos && Int32.TryParse(parts[firstValuePos], out firstValue) && Int32.TryParse(parts[secondValuePos], out secondValue))
            {
                result = new StatisticItem(parts[descriptionPos], firstValue, secondValue);
                return true;
            }
            else
            {
                result = new StatisticItem();
                return false;
            }
        }

        #endregion
    }
}
