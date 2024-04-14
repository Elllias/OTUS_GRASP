using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Condition_MoveInDirection_IsNotMoving : ICondition
    {
        private readonly IMoveInDirectionMotor engine;

        public Condition_MoveInDirection_IsNotMoving(IMoveInDirectionMotor engine)
        {
            this.engine = engine;
        }

        public bool IsTrue()
        {
            return !this.engine.IsMoving;
        }
    }
}