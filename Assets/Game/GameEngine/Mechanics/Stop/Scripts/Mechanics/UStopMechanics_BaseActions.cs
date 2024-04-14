using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Stop/Stop Mechanics «Base Actions»")]
    public sealed class UStopMechanics_BaseActions : MonoBehaviour
    {
        [SerializeField]
        private MonoEmitter stopEmitter;

        [Space]
        [SerializeField]
        private MonoAction[] actions;

        private void OnEnable()
        {
            foreach (var action in this.actions)
            {
                this.stopEmitter.AddListener(action);
            }
        }

        private void OnDisable()
        {
            foreach (var action in this.actions)
            {
                this.stopEmitter.RemoveListener(action);
            }
        }
    }
}