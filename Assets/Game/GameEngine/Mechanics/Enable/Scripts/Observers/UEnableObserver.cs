using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UEnableObserver : MonoBehaviour
    {
        [SerializeField]
        public MonoEntity entity;

        protected virtual void Awake()
        {
            var isEnable = this.entity.Get<IComponent_Enable>().IsEnable;
            this.SetEnable(isEnable);
        }

        protected virtual void OnEnable()
        {
            this.entity.Get<IComponent_Enable>().OnEnabled += this.SetEnable;
        }

        protected virtual void OnDisable()
        {
            this.entity.Get<IComponent_Enable>().OnEnabled -= this.SetEnable;
        }

        protected abstract void SetEnable(bool isEnable);
    }
}