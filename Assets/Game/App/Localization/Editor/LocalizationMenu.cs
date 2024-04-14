#if UNITY_EDITOR
using Unity.EditorCoroutines.Editor;
using UnityEditor;

namespace Game.Localization.UnityEditor
{
    internal static class LocalizationMenu
    {
        #region Text

        [MenuItem("Window/Localization/Texts", priority = 80)]
        internal static void ShowTextWindow()
        {
            EditorWindow.GetWindow(typeof(LocalizationTextWindow));
        }

        [MenuItem("Tools/Localization/Select Text Config", priority = 100)]
        internal static void SelectTextConfig()
        {
            Selection.activeObject = Configs.TextConfig;
        }

        [MenuItem("Tools/Localization/Reset Text Spreadsheet")]
        internal static void ResetTextSpreadsheet()
        {
            Configs.TextConfig.spreadsheet = new TextSpreadsheet();
        }

        [MenuItem("Tools/Localization/Update Text Spreadsheet")]
        internal static void UpdateSpreadsheet()
        {
            var routine = TextSpreadsheetDownloader.DownloadSpreadsheet(Configs.TextConfig);
            EditorCoroutineUtility.StartCoroutine(routine, Configs.TextConfig);
        }

        #endregion

        #region Sprite

        [MenuItem("Window/Localization/Sprites", priority = 80)]
        internal static void ShowSpriteWindow()
        {
            EditorWindow.GetWindow(typeof(LocalizationSpriteWindow));
        }

        [MenuItem("Tools/Localization/Select Sprite Config", priority = 100)]
        internal static void SelectSpriteConfig()
        {
            Selection.activeObject = Configs.SpriteConfig;
        }

        #endregion

        #region AudioClip

        [MenuItem("Window/Localization/Audio Clips", priority = 80)]
        internal static void ShowAudioClipWindow()
        {
            EditorWindow.GetWindow(typeof(LocalizationAudioClipWindow));
        }

        [MenuItem("Tools/Localization/Select Audio Clip Config", priority = 100)]
        internal static void SelectAudioClipConfig()
        {
            Selection.activeObject = Configs.AudioClipConfig;
        }

        #endregion
    }
}
#endif