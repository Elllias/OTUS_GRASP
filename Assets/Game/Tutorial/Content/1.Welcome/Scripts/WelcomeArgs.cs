namespace Game.Tutorial
{
    public sealed class WelcomeArgs
    {
        public readonly string title;

        public readonly string description;

        public WelcomeArgs(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}