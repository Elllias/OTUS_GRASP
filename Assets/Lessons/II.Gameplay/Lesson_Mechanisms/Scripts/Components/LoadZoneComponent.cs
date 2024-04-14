using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.Mech.Components
{
    public sealed class LoadZoneComponent : MonoBehaviour, ILoadZoneComponent
    {
        [SerializeField]
        private MonoIntVariableLimited loadStorage;

        public bool CanLoad()
        {
            return !this.loadStorage.IsLimit;
        }

        public void Load(int resources)
        {
            this.loadStorage.Current += resources;
        }
    }
}