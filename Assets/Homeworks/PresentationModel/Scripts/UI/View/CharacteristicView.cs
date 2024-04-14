using TMPro;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class CharacteristicView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _value;
        
        public void SetName(string charName)
        {
            _name.text = charName;
            
            // К сожалению, из за ContentSizeFilter нужен этот костыль.
            Canvas.ForceUpdateCanvases();
        }
        
        public void SetValue(int value)
        {
            _value.text = value.ToString();
            
            // К сожалению, из за ContentSizeFilter нужен этот костыль.
            Canvas.ForceUpdateCanvases();
        }

        public string GetName()
        {
            return _name.text;
        }
    }
}