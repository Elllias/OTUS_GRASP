using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public class MoveInDirectionState_SurfacePosition : StateFixedUpdate
    {
        public IMoveInDirectionMotor moveEngine;

        public ITransformEngine transform;

        public IValue<IWalkableSurface> surface;

        public IValue<float> speed;

        public void ConstructMotor(IMoveInDirectionMotor motor)
        {
            this.moveEngine = motor;
        }

        public void ConstructTransform(ITransformEngine transform)
        {
            this.transform = transform;
        }

        public void ConstructSurface(IValue<IWalkableSurface> surface)
        {
            this.surface = surface;
        }

        public void ConstructSpeed(IValue<float> speed)
        {
            this.speed = speed;
        }

        protected override void FixedUpdate(float deltaTime)
        {
            this.MoveInDirection(deltaTime);
        }

        private void MoveInDirection(float deltaTime)
        {
            var velocity = this.moveEngine.Direction * (this.speed.Current * deltaTime);
            if (this.surface.Current != null)
            {
                this.MoveBySurface(velocity);
            }
            else
            {
                this.transform.MovePosition(velocity);
            }
        }

        private void MoveBySurface(Vector3 velocity)
        {
            var nextPosition = this.transform.WorldPosition + velocity;
            var surface = this.surface.Current;
            if (surface.IsAvailablePosition(nextPosition))
            {
                this.transform.SetPosiiton(nextPosition);
            }
            else if (surface.FindAvailablePosition(nextPosition, out var clampedPosition))
            {
                this.transform.SetPosiiton(clampedPosition);
            }
        }
    }
}