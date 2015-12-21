
namespace Football
{
    public struct TeamResult
    {
        #region Constructors

        public TeamResult( string name , int goalsFor , int goalsAgainst )
            :this()
        {
            Name = name;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
        }

        #endregion

        #region Properties

        public string Name
        {
            get;
            private set;
        }

        public int GoalsFor
        {
            get;
            private set;
        }

        public int GoalsAgainst
        {
            get;
            private set;
        }

        public int Difference
        {
            get
            {
                return GoalsFor - GoalsAgainst;
            }
        }

        #endregion
    }
}
