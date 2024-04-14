using Game.UI;
using UnityEngine;

namespace Lessons.Gameplay.Mech
{
    public sealed class ConveyorWidget : MonoBehaviour
    {
        [SerializeField]
        private GameObject root;

        [SerializeField]
        private ProgressBar progressBar;

        public void SetProgress(float progress)
        {
            this.progressBar.SetProgress(progress);
        }

        public void SetVisible(bool isVisible)
        {
            this.root.SetActive(isVisible);
        }
    }
}