using Controllers;
using Core;

namespace Events
{
    public class AttackEvent
    {
        public HeroController Source;
        public HeroController Target;
    }
}