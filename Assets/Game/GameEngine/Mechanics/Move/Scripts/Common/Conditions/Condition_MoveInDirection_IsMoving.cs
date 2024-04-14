using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Condition_MoveInDirection_IsMoving : ICondition
    {
        private readonly IMoveInDirectionMotor engine;

        public Condition_MoveInDirection_IsMoving(IMoveInDirectionMotor engine)
        {
            this.engine = engine;
        }

        public bool IsTrue()
        {
            return this.engine.IsMoving;
        }
    }
}