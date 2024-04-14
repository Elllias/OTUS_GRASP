namespace Game.GameEngine
{
    public sealed class Component_ObjectType : IComponent_GetObjectType
    {
        public ObjectType ObjectType { get; }

        public Component_ObjectType(ObjectType objectType)
        {
            this.ObjectType = objectType;
        }
    }
}