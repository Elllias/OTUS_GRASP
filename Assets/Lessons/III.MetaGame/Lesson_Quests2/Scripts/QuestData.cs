using System;
using UnityEngine;

namespace Lessons.Meta
{
    [Serializable]
    public struct QuestData
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public string serializedState;
    }
}