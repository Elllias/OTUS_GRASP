using System;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public struct MissionData
    {
        [SerializeField]
        public string id;
        
        [SerializeField]
        public string serializedState;

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(serializedState)}: {serializedState}";
        }
    }
}