using System;

namespace Data
{
    public struct TimeData
    {
        public int Type;
        public DateTime DateTime;

        public override string ToString()
        {
            return $"Type: {((TimeType)Type).ToString()}, DateTime: {DateTime:yyyy-MM-dd HH:mm:ss}";
        }
    }
}