namespace Game.Tutorial
{
    public sealed class CongratulationsArgs
    {
        public readonly string title;

        public readonly string description;

        public CongratulationsArgs(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}