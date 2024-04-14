#if UNITY_EDITOR

using System;
using System.Linq;
using Game.Localization.UnityEditor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Game.Localization
{
    public sealed class TranslationKeyAttributeDrawer : OdinAttributeDrawer<TranslationKeyAttribute, string>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            //Draw label:
            EditorGUILayout.Space(4.0f);
            var rect = EditorGUILayout.GetControlRect();
            if (label != null)
            {
                EditorGUI.PrefixLabel(rect, label);
            }

            //Check pages:
            var textConfig = Configs.TextConfig;
            var pages = textConfig.spreadsheet.pages;
            if (pages == null || pages.Length <= 0)
            {
                EditorGUILayout.HelpBox("No pages!", MessageType.Error);
                return;
            }

            var pageIndex = 0;
            var pageNames = pages.Select(it => it.name).ToArray();
            
            //Define page:
            var key = this.ValueEntry.SmartValue;
            var separator = textConfig.pageSeparator;
            var separators = new[] {separator};

            string entityKey = null;
            
            if (!string.IsNullOrEmpty(key) && TextKeyParser.TryParse(key, separators, out var pageName, out entityKey))
            {
                pageIndex = Array.FindIndex(pageNames, it => it == pageName);
                if (pageIndex < 0)
                {
                    pageIndex = 0;
                }
            }

            //Define entity:
            var targetPage = pages[pageIndex];
            var entities = targetPage.entities;
            if (entities == null || entities.Length <= 0)
            {
                EditorGUILayout.HelpBox($"No entities for page {targetPage.name}!", MessageType.Error);
                return;
            }

            var entityIndex = 0;
            var entityKeys = entities.Select(it => it.key).ToArray();
            if (entityKey != null)
            {
                entityIndex = Array.FindIndex(entityKeys, it => it == entityKey);
                if (entityIndex < 0)
                {
                    entityIndex = 0;
                }
            }

            //Draw GUI:
            EditorGUILayout.BeginHorizontal();
            
            pageIndex = EditorGUILayout.Popup(pageIndex, pageNames);
            pageName = pageNames[pageIndex];

            entityIndex = EditorGUILayout.Popup(entityIndex, entityKeys);
            entityKey = entityKeys[entityIndex];

            this.ValueEntry.SmartValue = pageName + separator + entityKey;
            EditorGUILayout.EndHorizontal();
        }
    }
}

#endif