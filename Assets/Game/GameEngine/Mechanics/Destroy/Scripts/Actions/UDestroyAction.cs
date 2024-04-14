using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UDestroyAction : MonoBehaviour, IAction<DestroyArgs>
    {
        public abstract void Do(DestroyArgs destroyArgs);
    }
}