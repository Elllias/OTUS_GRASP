using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class EnumerableExtensions
    {
        public static string ToText<T>(this IEnumerable<T> list)
        {
            var text = new StringBuilder();

            text.Append("\n");

            foreach (var item in list)
            {
                text.Append(item.ToString() + "\n");
            }

            var stringText = text.ToString();

            if (stringText.Trim() == string.Empty)
            {
                stringText = "None";
            }

            return stringText;
        }
    }
}