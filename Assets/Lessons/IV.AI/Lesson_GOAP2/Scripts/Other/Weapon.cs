using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField]
        private Bullet bulletPrefab;

        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private int bullets = 10;
        
        private float fireCountdown;

        public bool CanFire()
        {
            return this.fireCountdown <= 0 && this.bullets > 0;
        }
        
        public void Fire(Vector3 direction)
        {
            if (!this.CanFire())
            {
                return;
            }
            
            var spawnPosition = this.firePoint.position;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            GameObject.Instantiate(this.bulletPrefab, spawnPosition, rotation, null);

            this.bullets--;
            this.fireCountdown += 2;
        }

        private void FixedUpdate()
        {
            if (this.fireCountdown > 0)
            {
                this.fireCountdown -= Time.fixedDeltaTime;
            }
        }
    }
}