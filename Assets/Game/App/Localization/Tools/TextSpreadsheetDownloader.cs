#if UNITY_EDITOR
using System.Collections;
using Elementary;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable CS0618

namespace Game.Localization.UnityEditor
{
    public static class TextSpreadsheetDownloader
    {
        public static IEnumerator DownloadSpreadsheet(LocalizationTextConfig config)
        {
            var uri = config.uri;
            if (uri == null)
            {
                yield break;
            }

            var spreadsheet = config.spreadsheet;

            var pages = spreadsheet.pages;
            var pageCount = pages.Length;
            if (pageCount <= 0)
            {
                yield break;
            }
            
            for (var i = 0; i < pageCount; i++)
            {
                var page = pages[i];
                var pageName = page.name;
                var pageBody = new Reference<string>();

                yield return DownloadPageText(pageName, uri, pageBody);

                page = new TextSpreadsheet.Page
                {
                    name = pageName,
                    entities = TextEntityParser.ParseTextByEntities(pageBody.Value)
                };
                
                pages[i] = page;
            }
            
            config.spreadsheet = new TextSpreadsheet
            {
                pages = pages
            };
            
            var serializedObject = new SerializedObject(config);
            serializedObject.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
        }

        private static IEnumerator DownloadPageText(string pageId, string sheetUri, Reference<string> pageText)
        {
            var uri = $"{sheetUri}/gviz/tq?tqx=out:csv&sheet={pageId}";
            using (var request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError)
                {
                    Debug.LogError($"Update page {pageId} error: {request.error}");
                    yield break;
                }

                var text = request.downloadHandler.text;
                Debug.Log($"Page {pageId} is loaded! \n Text: \n {text}");
                pageText.Value = text;
            }
        }
    }
}
#endif