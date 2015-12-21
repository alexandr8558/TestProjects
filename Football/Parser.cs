using System;

namespace Football
{
    public class Parser
    {
        #region Methods

        public bool TryParse(string value, char splitter , out TeamResult result)
        {
            string[] parts;
            int goalsFor;
            int goalsAgainst;

            parts = value.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries);

            if ( parts.Length > 8 && Int32.TryParse(parts[6], out goalsFor) && Int32.TryParse(parts[8], out goalsAgainst))
            {
                result = new TeamResult(parts[ 1 ], goalsFor, goalsAgainst);
                return true;
            }
            else
            {
                result = new TeamResult();
                return false;
            }
        }

        #endregion
    }
}
