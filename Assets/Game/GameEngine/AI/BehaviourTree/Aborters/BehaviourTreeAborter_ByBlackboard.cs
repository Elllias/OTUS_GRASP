using System;
using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using Declarative;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BehaviourTreeAborter_ByBlackboard :
        IEnableListener,
        IDisableListener,
        IUpdateListener
    {
        public IBehaviourTree tree;

        public IBlackboard blackboard;
        
        [BlackboardKey]
        [SerializeField]
        public List<string> blackboardKeys;

        private bool abortRequired;

        void IEnableListener.OnEnable()
        {
            this.blackboard.OnVariableAdded += this.OnVariableChanged;
            this.blackboard.OnVariableRemoved += this.OnVariableChanged;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (this.abortRequired)
            {
                this.tree.Abort();
                this.abortRequired = false;
            }
        }

        void IDisableListener.OnDisable()
        {
            this.blackboard.OnVariableAdded -= this.OnVariableChanged;
            this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
        }
        
        private void OnVariableChanged(string key, object value)
        {
            if (this.blackboardKeys.Contains(key))
            {
                this.abortRequired = true;
            }
        }
    }
}