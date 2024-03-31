using System;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet, GameObject> OnCollisionEntered;

        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private int _damage;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision.gameObject);
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