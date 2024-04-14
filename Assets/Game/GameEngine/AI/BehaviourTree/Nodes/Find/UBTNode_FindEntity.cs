using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Find Entity»")]
    public sealed class UBTNode_FindEntity : UnityBehaviourNode,
        IBlackboardInjective,
        IGameConstructElement
    {
        public IBlackboard Blackboard { private get; set; }

        private EntitiesService entitiesService;

        [SerializeField]
        private ScriptableEntityCondition entityCondition;

        [BlackboardKey]
        [SerializeField]
        private string entityParameterName;
        
        protected override void Run()
        {
            if (this.entitiesService.FindEntity(this.entityCondition, out var entity))
            {
                this.Blackboard.ReplaceVariable(this.entityParameterName, entity);
                this.Return(true);
            }
            else
            {
                this.Return(false);
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.entitiesService = context.GetService<EntitiesService>();
        }
    }
}