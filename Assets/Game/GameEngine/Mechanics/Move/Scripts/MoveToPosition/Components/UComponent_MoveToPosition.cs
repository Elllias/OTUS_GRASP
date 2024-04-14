using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Component «Move To Position»")]
    public sealed class UComponent_MoveToPosition : MonoBehaviour, 
        IComponent_MoveToPositiion,
        IComponent_CanMoveToPositiion
    {
        [SerializeField]
        private UMoveToPositionMotor engine;
    
        public void Move(Vector3 position)
        {
            this.engine.StartMove(position);
        }

        public bool CanMove(Vector3 position)
        {
            return this.engine.CanStartMove(position);
        }
    }
}