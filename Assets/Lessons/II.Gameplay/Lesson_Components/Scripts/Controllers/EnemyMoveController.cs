using UnityEngine;

namespace Lessons.Architecture.Components
{
    public class EnemyMoveController : AbstractMoveController
    {
        [SerializeField]
        private Enemy enemy;  //Тип2

        protected override void Move(Vector3 direction)
        {
            const float speed = 5.0f;
            this.enemy.Move(direction * (speed * Time.deltaTime));
        }
    }
}