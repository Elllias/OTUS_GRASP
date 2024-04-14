using AI.Blackboards;
using Entities;
using UnityEngine;
using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;

namespace Lessons.AI.Lesson_Commands2
{
    public sealed class BlackboardInstaller : MonoBehaviour
     {
         [SerializeField]
         private Blackboard blackboard;

         [Space]
         [BlackboardKey]
         [SerializeField]
         private string unitKey;

         [SerializeField]
         private MonoEntity unitEntity;
         
         private void Awake()
         {
             this.blackboard.SetVariable(this.unitKey, this.unitEntity);
         }
     }
}