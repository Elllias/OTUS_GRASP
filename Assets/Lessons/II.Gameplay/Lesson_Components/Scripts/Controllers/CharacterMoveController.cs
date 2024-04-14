using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class CharacterMoveController : AbstractMoveController
     {
         [SerializeField]
         private Character character; //Тип1

         protected override void Move(Vector3 direction)
         {
             const float speed = 5.0f;
             this.character.Move(direction * (speed * Time.deltaTime));
         }
     }
}