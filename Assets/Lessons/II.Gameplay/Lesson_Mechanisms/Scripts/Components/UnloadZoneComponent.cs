using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.Mech
{
    public class UnloadZoneComponent : MonoBehaviour, IUnloadZoneComponent
    {
        [SerializeField]
        private MonoIntVariableLimited unloadStorage;

        public bool CanUnload()
        {
            return this.unloadStorage.Current > 0;
        }

        public int UnloadAll()
        {
            var result = this.unloadStorage.Current;
            this.unloadStorage.Current = 0;
            return result;
        }
    }
}