using UnityEngine;
using UnityEngine.UI;

namespace SaveSystem.UI
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