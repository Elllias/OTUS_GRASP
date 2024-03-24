using Common;
using Interface;
using UnityEngine;

namespace Bullet
{
    public sealed class BulletsController : MonoBehaviour
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private global::Bullet.Bullet _prefab;
        [SerializeField] private Transform _worldTransform;

        private Pool<global::Bullet.Bullet> _bulletPool;

        private void Start()
        {
            _bulletPool = new Pool<global::Bullet.Bullet>(_prefab, _poolContainer, _worldTransform);
        }

        public void Shoot(Vector2 shootPoint, Vector2 targetPoint, BulletConfig bulletConfig)
        {
            var bullet = _bulletPool.Get(shootPoint, Quaternion.identity);

            bullet.Initialize(bulletConfig);
            bullet.SetPosition(shootPoint);
            bullet.SetVelocity((targetPoint - shootPoint).normalized * bulletConfig.Speed);

            bullet.OnCollisionEntered += OnCollisionEntered;
        }

        private void OnCollisionEntered(global::Bullet.Bullet bullet, GameObject collisionObject)
        {
            if (collisionObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(bullet.GetDamage());
            }

            bullet.OnCollisionEntered -= OnCollisionEntered;
            _bulletPool.Release(bullet);
        }
    }
}