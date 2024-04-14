using System;

namespace Game.Localization
{
    public static class TextKeyParser
    {
        public static bool TryParse(
            string fullKey,
            string[] separator,
            out string pageName,
            out string entityKey
        )
        {
            var chunks = fullKey.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (chunks.Length != 2)
            {
                pageName = null;
                entityKey = null;
                return false;
            }

            pageName = chunks[0];
            entityKey = chunks[1];
            return true;
        }
    }
}