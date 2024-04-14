using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Component «Patrol By Points»")]
    public sealed class UComponent_PatrolByPoints : MonoBehaviour, IComponent_PatrolByPoints
    {
        [SerializeField]
        private UPatrolByPointsEngine engine;
        
        public void StartPatrol(PatrolByPointsOperation operation)
        {
            this.engine.StartPatrol(operation);
        }
    }
}