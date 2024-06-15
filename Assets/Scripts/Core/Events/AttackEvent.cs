using Core.Controllers;
using Core.Data;

namespace Core.Events
{
    public class AttackEvent
    {
        public Hero Source { get; private set; }
        public Hero Target { get; private set; }

        public AttackEvent(Hero source, Hero target)
        {
            Source = source;
            Target = target;
        }
    }
}