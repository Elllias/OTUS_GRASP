using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_TransformEngine :
        IComponent_GetPosition,
        IComponent_SetPosition,
        IComponent_GetRotation,
        IComponent_SetRotation,
        IComponent_LookAtPosition
    {
        public Vector3 Position
        {
            get { return this.engine.WorldPosition; }
        }

        public Quaternion Rotation
        {
            get { return this.engine.WorldRotation; }
        }

        private readonly ITransformEngine engine;

        public Component_TransformEngine(ITransformEngine engine)
        {
            this.engine = engine;
        }

        public void SetPosition(Vector3 position)
        {
            this.engine.SetPosiiton(position);
        }

        public void SetRotation(Quaternion rotation)
        {
            this.engine.SetRotation(rotation);
        }

        public void LookAtPosition(Vector3 position)
        {
            this.engine.LookAtPosition(position);
        }
    }
}