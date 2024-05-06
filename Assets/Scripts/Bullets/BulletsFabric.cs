using Common;
using Interface;
using UnityEngine;
using VContainer.Unity;

namespace Bullets
{
    public class BulletsFabric
    {
        private readonly Pool<Bullet> _bulletPool;

        public BulletsFabric(BulletsController bulletsController, Bullet prefab)
        {
            _bulletPool = new Pool<Bullet>(prefab, 
                bulletsController.GetPoolTransform(), 
                bulletsController.GetWorldTransform());
        }

        public void Shoot(Vector2 shootPoint, Vector2 targetPoint, BulletConfig bulletConfig)
        {
            var bullet = _bulletPool.Get(shootPoint, Quaternion.identity);

            bullet.Initialize(bulletConfig);
            bullet.SetPosition(shootPoint);
            bullet.SetVelocity((targetPoint - shootPoint).normalized * bulletConfig.Speed);

            bullet.OnCollisionEntered += OnCollisionEntered;
        }

        private void OnCollisionEntered(Bullet bullet, GameObject collisionObject)
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