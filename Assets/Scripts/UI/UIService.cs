using UnityEngine;

namespace UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField]
        private HeroListView bluePlayer;

        [SerializeField]
        private HeroListView redPlayer;

        public HeroListView GetBluePlayer()
        {
            return this.bluePlayer;
        }

        public HeroListView GetRedPlayer()
        {
            return this.redPlayer;
        }
    }
}