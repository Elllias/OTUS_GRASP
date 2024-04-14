using Cysharp.Threading.Tasks;
using Game.Gameplay.Enemies;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public interface IComponent_RangeCombat
    {
        bool CanFire();

        void Fire(Vector3 direction);
    }
    
    public sealed class Component_RangeCombat : MonoBehaviour, IComponent_RangeCombat
    {
        [SerializeField]
        private Weapon weapon;

        [SerializeField]
        private EnemyWarriorModel model;
        
        public bool CanFire()
        {
            return this.weapon.CanFire();
        }

        public async void Fire(Vector3 direction)
        {
            this.model.core.transformEngine.LookInDirection(direction);
            this.model.animations.animator.Play("Cast", -1, 0);

            await UniTask.Delay(millisecondsDelay: 250);
            this.weapon.Fire(direction);
        }
    }
}