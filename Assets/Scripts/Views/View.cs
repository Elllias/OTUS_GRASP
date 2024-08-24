using Leopotam.EcsLite;
using UnityEngine;

namespace Views
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Initialize(EcsWorld eventWorld);
    }
}