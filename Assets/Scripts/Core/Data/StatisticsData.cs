using System;

namespace Core.Data
{
    [Serializable]
    public class StatisticsData
    {
        private const string STRING_FORMAT = "{0} / {1}";
        
        public int Damage;
        public int Health;

        public override string ToString()
        {
            return string.Format(STRING_FORMAT, Damage, Health);
        }
    }
}