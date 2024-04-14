using UnityEngine;

namespace Game.GameEngine
{
    [AddComponentMenu("GameEngine/ObjectType/Component «Object Type»")]
    public sealed class UComponent_ObjectType : MonoBehaviour, IComponent_GetObjectType
    {
        public ObjectType ObjectType
        {
            get { return this.objectType.Value; }
        }


        [SerializeField]
        private ObjectTypeAdapter objectType;
    }
}