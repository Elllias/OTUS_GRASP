using TMPro;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class NameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public void SetNameText(string text)
        {
            _text.text = text;
        }
    }
}