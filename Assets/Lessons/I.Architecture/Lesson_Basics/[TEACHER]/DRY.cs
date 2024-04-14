// // ReSharper disable ArrangeTypeModifiers
// // ReSharper disable ArrangeTypeMemberModifiers
//
// using UnityEngine;
// // ReSharper disable UnusedType.Global
// // ReSharper disable UnusedMember.Local
//
// namespace Lessons.Architecture.Basics
// {
//     //BAD

using UnityEngine;

    class Hero {
        void Move(Vector3 direction) {
            //Move logic
        }

        void Jump() {
            //Jump logic
        }

        void Shoot() {
            //Shoot logic
        }
    }

    class Enemy {
        
        void Move(Vector3 direction) {
            //Move logic
        }

        void Shoot() {
            //Shoot logic
        }
    }

    class NPC {
        
        void Move(Vector3 direction) {
            //Move logic
        }

        void Jump() {
            //Jump logic
        }
    }



//     
//     
//
//     
//     
//     

     // class MoveComponent {
     //     void Move(Vector3 direction) {
     //         //Move logic
     //     }
     // }
     //
     // class JumpComponent {
     //     void Jump() {
     //         //Jump logic
     //     }
     // }
     //
     // class ShootComponent {
     //     void Shoot() {
     //         //Shoot logic
     //     }
     // }




// }