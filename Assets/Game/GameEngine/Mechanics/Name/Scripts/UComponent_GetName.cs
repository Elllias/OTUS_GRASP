using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Name/Component «Get Name»")]
    public sealed class UComponent_GetName : MonoBehaviour, IComponent_GetName
    {
        public string Name
        {
            get { return _name.Current; }
        }

        [SerializeField]
        private StringAdapter _name;
    }
}