using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button GetButton()
        {
            return _button;
        }
    }
}