using System.Collections.Generic;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "TutorialList",
        menuName = "Tutorial/New TutorialList",
        order = 35
    )]
    public sealed class TutorialList : ScriptableObject
    {
        public int LastIndex
        {
            get { return this.steps.Count - 1; }
        }

        [SerializeField]
        private List<TutorialStep> steps = new();

        public TutorialStep this[int index]
        {
            get { return this.steps[index]; }
        }
        
        public int IndexOf(TutorialStep step)
        {
            return this.steps.IndexOf(step);
        }

        public bool IsLast(int index)
        {
            return index >= this.steps.Count - 1;
        }
    }
}