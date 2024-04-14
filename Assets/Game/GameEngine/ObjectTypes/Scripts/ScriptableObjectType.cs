using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Object Type",
        menuName = "GameEngine/Object Types/New Scriptable Object Type"
    )]
    public sealed class ScriptableObjectType : ScriptableObject
    {
        public ObjectType ObjectType
        {
            get { return this.objectType; }
        }

        [SerializeField]
        private ObjectType objectType;
    }
}