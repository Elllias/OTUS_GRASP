using Common;
using Interface;
using UnityEngine;
using VContainer.Unity;

namespace Bullet
{
    public class BulletsController : MonoBehaviour, IStartable
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _worldTransform;

        private Pool<Bullet> _bulletPool;

        public void Start()
        {
            _bulletPool = new Pool<Bullet>(_prefab, _poolContainer, _worldTransform);
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