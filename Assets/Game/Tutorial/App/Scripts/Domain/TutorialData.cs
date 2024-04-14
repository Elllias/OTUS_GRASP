using System;
using UnityEngine;

namespace Game.Tutorial.App
{
    [Serializable]
    public struct TutorialData
    {
        [SerializeField]
        public int stepIndex;

        [SerializeField]
        public bool isCompleted;
    }
}