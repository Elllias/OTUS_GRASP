using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class Character : MonoBehaviour
    {
        public event Action<int> OnHitPointsChanged
        {
            add { this.hitPoints.OnValueChanged += value; }
            remove { this.hitPoints.OnValueChanged -= value; }
        }
        
        public event Action OnDeath
        {
            add { this.deathReceiver.OnEvent += value; }
            remove { this.deathReceiver.OnEvent -= value; }
        }

        public int HitPoints
        {
            get { return this.hitPoints.Value; }
        }

        [SerializeField]
        private IntBehaviour hitPoints;

        [SerializeField]
        private EventReceiver attackReceiver;

        [SerializeField]
        private IntEventReceiver takeDamageReceiver;

        [SerializeField]
        private EventReceiver deathReceiver;

        [SerializeField]
        private Vector3EventReceiver moveReceiver;

        [Title("Methods")]
        [Button]
        public void Attack()
        {
            this.attackReceiver.Call();
        }

        [Button]
        public void TakeDamage(int damage)
        {
            this.takeDamageReceiver.Call(damage);
        }

        [Button]
        public void Move(Vector3 vector)
        {
            this.moveReceiver.Call(vector);
        }
    }
}