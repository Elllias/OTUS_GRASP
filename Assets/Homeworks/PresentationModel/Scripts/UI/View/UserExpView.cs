using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class UserExpView : MonoBehaviour
    {
        [SerializeField] private Slider _expSlider;
        [SerializeField] private TMP_Text _expText;

        public void SetSliderValue(float value)
        {
            _expSlider.value = value;
        }
        
        public void SetText(string text)
        {
            _expText.text = text;
        }
    }
}
