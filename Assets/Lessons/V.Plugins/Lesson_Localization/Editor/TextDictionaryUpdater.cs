#if UNITY_EDITOR
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618

namespace Lessons.Plugins.LocalizationLesson
{
    public static class TextDictionaryUpdater
    {
        public static IEnumerator UpdateDictionaryRoutine(TextDictionary config)
        {
            var uri = config.uri;
            if (uri == null)
            {
                yield break;
            }

            var downloadResult = new DownloadResult();
            
            yield return DownloadContent(uri, downloadResult);
            
            config.entities = TextDictionaryParser.ParseTextByEntities(downloadResult.content);
            EditorUtility.SetDirty(config);

            var serializedObject = new SerializedObject(config);
            
            serializedObject.ApplyModifiedProperties();
            
            // File.WriteAllText("LocalizationKeys.cs", "public static class");
            
            AssetDatabase.SaveAssets();
        }

        private static IEnumerator DownloadContent(string uri, DownloadResult result)
        {
            var fullURI = $"{uri}/gviz/tq?tqx=out:csv&sheet={1}";
            
            using (var request = UnityWebRequest.Get(fullURI))
            {
                yield return request.SendWebRequest();
                
                if (request.isNetworkError)
                {
                    Debug.LogError($"Download content error: {request.error}");
                    yield break;
                }

                var text = request.downloadHandler.text;
                Debug.Log($"Content is downloaded! \n Text: \n {text}");
                result.content = text;
            }
        }

        private sealed class DownloadResult
        {
            public string content;
        }
    }
}

#endif
