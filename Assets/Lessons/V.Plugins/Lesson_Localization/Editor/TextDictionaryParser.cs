using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
   public static class TextDictionaryParser
    {
        public static LocalizedEntity<string>[] ParseTextByEntities(string text)
        {
            var lines = ParseTextByLines(text);
            var lineCount = lines.Count;

            if (lineCount <= 1) //First line is the header
            {
                return new LocalizedEntity<string>[0];
            }

            var headerLine = lines[0];
            var languages = ParseHeaderByLanguages(headerLine);

            var entities = new LocalizedEntity<string>[lineCount - 1]; //Without header line:
            for (var i = 0; i < lineCount - 1; i++)
            {
                var line = lines[i + 1]; //Shift because languages row is the first 
                var entity = ParseEntityByLine(line, languages);
                entities[i] = entity;
            }

            return entities;
        }

        private static SystemLanguage[] ParseHeaderByLanguages(string headerLine)
        {
            var headerChunks = ParseLine(headerLine);
            var count = headerChunks.Count - 1; //Without first id column

            var languages = new SystemLanguage[count];
            for (var i = 0; i < count; i++)
            {
                var languageText = headerChunks[i + 1]; //Shift because id column is the first 
                if (!Enum.TryParse(languageText, out SystemLanguage language))
                {
                    Debug.LogError($"Can not parse language name: {languageText}");
                }

                languages[i] = language;
            }

            return languages;
        }

        public static LocalizedEntity<string> ParseEntityByLine(string line, SystemLanguage[] languages)
        {
            var chunks = ParseLine(line);
            var key = chunks[0];
            
            var translationCount = languages.Length;
            var translations = new LocalizedProperty<string>[translationCount];
            
            for (var j = 0; j < translationCount; j++)
            {
                var language = languages[j];
                var value = chunks[j + 1]; //because Key is the first 
                var translation = new LocalizedProperty<string>
                {
                    language = language,
                    value = value.Trim()
                };
                translations[j] = translation;
            }

            return new LocalizedEntity<string>
            {
                key = key,
                translations = translations
            };
        }

        private static List<string> ParseTextByLines(string text)
        {
            var lines = new List<string>();
            var textLength = text.Length;
            var currentPointer = 0;
            var startPosition = 0;
            var quotesMode = false;
            
            while (currentPointer < textLength)
            {
                var character = text[currentPointer++];
                if (character == '\n' && !quotesMode)
                {
                    var lineLength = currentPointer - startPosition - 1;
                    var line = text.Substring(startPosition, lineLength);
                    lines.Add(line);
                    startPosition = currentPointer;
                }

                if (character == '"')
                {
                    quotesMode = !quotesMode;
                }
            }

            var endLineLength = currentPointer - startPosition;
            var endLine = text.Substring(startPosition, endLineLength);
            lines.Add(endLine);
            return lines;
        }

        private static List<string> ParseLine(string line)
        {
            var words = new List<string>();
            var lineLength = line.Length;
            var currentPointer = 0;
            var startPosition = 0;
            var readMode = false;
            while (currentPointer < lineLength)
            {
                var currentCharacter = line[currentPointer++];
                if (currentCharacter != '"')
                {
                    continue;
                }

                if (!readMode)
                {
                    readMode = true;
                    startPosition = currentPointer;
                    continue;
                }

                var wordLength = currentPointer - startPosition - 1;
                var word = line.Substring(startPosition, wordLength);
                words.Add(word);
                readMode = false;
            }

            return words;
        }
    }
}