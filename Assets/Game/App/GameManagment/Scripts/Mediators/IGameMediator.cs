namespace Game.App
{
    public interface IGameMediator
    {
        void SetupData(GameRepository repository);

        void SaveData(GameRepository repository);
    }
}