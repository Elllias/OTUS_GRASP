using Elementary;

namespace Lessons.Architecture.Declarative
{
    public interface ITakeDamageComponent
    {
        void TakeDamage(int damage);
    }

    public sealed class TakeDamageComponent : ITakeDamageComponent
    {
        private readonly IEmitter<int> takeDamageEvent;

        public TakeDamageComponent(IEmitter<int> takeDamageEvent)
        {
            this.takeDamageEvent = takeDamageEvent;
        }

        public void TakeDamage(int damage)
        {
            this.takeDamageEvent.Call(damage);
        }
    }
}