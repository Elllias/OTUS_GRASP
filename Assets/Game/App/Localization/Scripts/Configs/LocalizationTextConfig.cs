using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Localization
{
    [CreateAssetMenu(
        fileName = "LocalizationTextConfig",
        menuName = "Localization/New LocalizationTextConfig"
    )]
    public class LocalizationTextConfig : ScriptableObject
    {
#if UNITY_EDITOR
        [Header("Google Sheets URI")]
        [TextArea]
        [SerializeField]
        public string uri;
#endif

        [FormerlySerializedAs("pageSplitter")]
        [Header("Options")]
        [SerializeField]
        public string pageSeparator = "|";
        
        [Header("Text")]
        [SerializeField]
        public TextSpreadsheet spreadsheet = new TextSpreadsheet();
    }
}