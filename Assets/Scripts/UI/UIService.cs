using UnityEngine;

namespace UI
{
    public sealed class UIService : MonoBehaviour
    {
        [SerializeField] private HeroListView _bluePlayer;
        [SerializeField] private HeroListView _redPlayer;

        public HeroListView GetBluePlayer()
        {
            return this._bluePlayer;
        }

        public HeroListView GetRedPlayer()
        {
            return this._redPlayer;
        }
    }
}