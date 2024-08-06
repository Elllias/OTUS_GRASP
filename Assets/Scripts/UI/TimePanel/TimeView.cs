using TMPro;
using UnityEngine;

namespace UI.TimePanel
{
    public class TimeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
