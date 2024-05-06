using Bullets;
using UnityEngine;

namespace Component.Shooting
{
    public class ShootingComponent : MonoBehaviour
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private BulletConfig _bulletConfig;

        private ShootingController _controller;
        
        public void Construct(BulletsController bulletsController)
        {
            _controller = new ShootingController(bulletsController, _prefab, _bulletSpawnPoint, _bulletConfig);
        }

        public ShootingController GetController()
        {
            return _controller;
        }
    }
}