using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Id/Component «Id»")]
    public sealed class UComponent_Id : MonoBehaviour, IComponent_GetId
    {
        public string Id
        {
            get { return this.id.Current; }
        }

        [SerializeField]
        private StringAdapter id;
    }
}