using TMPro;
using UnityEngine;

namespace UI.Base
{
    public class TextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}