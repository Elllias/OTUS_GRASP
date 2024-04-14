using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class DestroyEventReceiver : MonoBehaviour
    {
        public event Action<DestroyArgs> OnDestroy;

        [SerializeField]
        private UDestroyAction[] actions; 

        [Button]
        [GUIColor(0, 1, 0)]
        public void Call(DestroyArgs destroyArgs)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do(destroyArgs);
            }
        
            this.OnDestroy?.Invoke(destroyArgs);
        }
    }
}