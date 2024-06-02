using UnityEngine;
using UnityEngine.UI;

namespace SaveSystem.UI
{
    public class SaveLoaderView : MonoBehaviour
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;

        public Button GetSaveButton()
        {
            return _saveButton;
        }

        public Button GetLoadButton()
        {
            return _loadButton;
        }
    }
}