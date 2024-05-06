using System;
using Interface;
using UnityEngine;

namespace Bullet
{
    public sealed class Bullet : MonoBehaviour, IPauseListener, IResumeListener, IFinishListener
    {
        public event Action<Bullet, GameObject> OnCollisionEntered;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private int _damage;

        private Vector3 _velocity;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision.gameObject);
        }
        
        public void OnPause()
        {
            _velocity = _rigidbody.velocity;
            
            SetVelocity(Vector3.zero);
        }

        public void OnResume()
        {
            SetVelocity(_velocity);
        }
        
        public void OnFinish()
        {
            SetVelocity(Vector3.zero);
        }

        public void Initialize(BulletConfig bulletConfig)
        {
            _damage = bulletConfig.Damage;
            _spriteRenderer.color = bulletConfig.Color;
            gameObject.layer = (int)bulletConfig.PhysicsLayer;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}