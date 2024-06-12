using Controllers;

namespace Core.Tasks
{
    public class RedTurnTask : Task
    {
        private readonly HeroController _hero;

        public RedTurnTask(HeroController hero)
        {
            _hero = hero;
        }
        
        protected override void OnRun()
        {
            
        }

        protected override void OnFinish()
        {
            
        }
    }
}