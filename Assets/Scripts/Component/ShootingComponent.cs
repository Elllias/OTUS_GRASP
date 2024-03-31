using Bullet;
using UnityEngine;

namespace Component
{
    public class ShootingComponent : MonoBehaviour
    {
        [SerializeField] private BulletsController _bulletsController;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private BulletConfig _bulletConfig;

        private Transform _target;

        public void Shoot()
        {
            var targetPoint = !_target ? _bulletSpawnPoint.position + Vector3.up : _target.position;

            _bulletsController.Shoot(_bulletSpawnPoint.position, targetPoint, _bulletConfig);
        }

        public void SetTargetPoint(Transform targetPoint)
        {
            _target = targetPoint;
        }

        public void SetBulletController(BulletsController bulletsController)
        {
            _bulletsController = bulletsController;
        }
    }
}