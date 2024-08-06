using System;
using System.Collections.Generic;

namespace Data
{
    public class UserTimeData
    {
        public int UserId;
        public List<TimeData> TimesData;
    }

    public struct TimeData
    {
        public TimeType TimeType;
        public DateTime DateTime;

        public override string ToString()
        {
            return $"TimeType: {TimeType}, DateTime: {DateTime:yyyy-MM-dd HH:mm:ss}";
        }
    }
}