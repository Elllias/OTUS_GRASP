using GameSystem;

namespace Game.Meta
{
    public sealed class MissionFactory
    {
        [GameInject]
        private GameContext gameContext;

        public Mission CreateMission(MissionConfig config)
        {
            var mission = config.InstantiateMission();
            GameInjector.Inject(this.gameContext, mission);
            return mission;
        }
    }
}