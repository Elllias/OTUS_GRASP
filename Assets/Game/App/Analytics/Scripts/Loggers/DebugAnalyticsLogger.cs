using System.Text;
using UnityEngine;

namespace Game.App
{
    public sealed class DebugAnalyticsLogger : IAnalyticsLogger
    {
        private readonly string colorHtml;

        private readonly StringBuilder stringBuilder;
        
        public DebugAnalyticsLogger(Color color)
        {
            this.colorHtml = ColorUtility.ToHtmlStringRGBA(color);
            this.stringBuilder = new StringBuilder();
        }

        public void LogEvent(string eventName, params AnalyticsParameter[] parameters)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                eventName = AnalyticsConst.UNDEFINED;
            }
            
            this.stringBuilder.Clear();
            this.stringBuilder
                .Append("Log Event: ")
                .Append($"<color=#{this.colorHtml}>")
                .Append($"{eventName}");

            if (parameters is {Length: > 0})
            {
                this.stringBuilder.Append(", parameters: ");
                foreach (var parameter in parameters)
                {
                    this.stringBuilder.Append($"(key: {parameter.name}, value: {parameter.value})");
                }
            }

            this.stringBuilder.Append("</color>");
            
            Debug.Log(this.stringBuilder.ToString());
        }
    }
}