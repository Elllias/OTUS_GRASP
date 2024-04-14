using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "Behaviour Tree Aborter «By Blackboard»")]
    public sealed class UBehaviourTreeAborter_ByBlackboard : MonoBehaviour,
        IBehaviourTreeInjective,
        IBlackboardInjective,
        IGameStartElement,
        IGameFinishElement
    {
        public IBehaviourTree Tree { private get; set; }

        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private List<string> addBlackboardKeys;

        [BlackboardKey]
        [SerializeField]
        private List<string> removeBlackboardKeys;

        private bool abortRequired;

        private void Awake()
        {
            this.enabled = false;
        }

        private void Update()
        {
            if (this.abortRequired)
            {
                this.Tree.Abort();
                this.abortRequired = false;
            }
        }

        void IGameStartElement.StartGame()
        {
            this.Blackboard.OnVariableAdded += this.OnVariableAdded;
            this.Blackboard.OnVariableRemoved += this.OnVariableRemoved;
            this.enabled = true;
        }

        void IGameFinishElement.FinishGame()
        {
            this.Blackboard.OnVariableAdded -= this.OnVariableAdded;
            this.Blackboard.OnVariableRemoved -= this.OnVariableRemoved;
            this.enabled = false;
        }

        private void OnVariableAdded(string key, object value)
        {
            if (this.addBlackboardKeys.Contains(key))
            {
                this.abortRequired = true;
            }
        }

        private void OnVariableRemoved(string key, object value)
        {
            if (this.removeBlackboardKeys.Contains(key))
            {
                this.abortRequired = true;
            }
        }
    }
}