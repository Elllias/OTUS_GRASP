using Entities;
using GameSystem;
using Sirenix.Utilities;
using UnityEngine;

namespace Lessons.Tutorial
{
    public class CompleteObserver_ShowTrees : CompleteObserver
    {
        [SerializeField]
        private MonoEntity[] trees;
        
        protected override void InitGame(GameContext context, bool isCompleted)
        {
            base.InitGame(context, isCompleted);
            this.trees.ForEach(it => it.gameObject.SetActive(isCompleted));
        }

        protected override void OnComplete()
        {
            base.OnComplete();
            this.trees.ForEach(it => it.gameObject.SetActive(true));
        }
    }
}