using Bullets;
using UnityEngine;

namespace Component.Shooting
{
    public class ShootingController
    {
        private readonly Transform _bulletSpawnPoint;
        private readonly BulletConfig _bulletConfig;
        private readonly BulletsFabric _bulletsFabric;
        
        private Transform _target;

        public ShootingController(
            BulletsController controller,
            Bullet prefab,
            Transform bulletSpawnPoint,
            BulletConfig bulletConfig)
        {
            _bulletSpawnPoint = bulletSpawnPoint;
            _bulletConfig = bulletConfig;
            _bulletsFabric = new BulletsFabric(controller, prefab);
        }

        public void Shoot()
        {
            var targetPoint = !_target ? _bulletSpawnPoint.position + Vector3.up : _target.position;

            _bulletsFabric.Shoot(_bulletSpawnPoint.position, targetPoint, _bulletConfig);
        }

        public void SetTargetPoint(Transform targetPoint)
        {
            _target = targetPoint;
        }
    }
}