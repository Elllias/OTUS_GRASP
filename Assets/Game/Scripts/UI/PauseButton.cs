using UnityEngine;
using UnityEngine.UI;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        
        [SerializeField]
        private PauseScreen pauseScreen;

        private void OnEnable()
        {
            this.button.onClick.AddListener(this.pauseScreen.Show);
        }

        private void OnDisable()
        {
            this.button.onClick.RemoveListener(this.pauseScreen.Show);
        }
    }
}