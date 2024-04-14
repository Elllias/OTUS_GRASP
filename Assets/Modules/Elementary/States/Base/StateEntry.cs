namespace Elementary
{
    public readonly struct StateEntry<T>
    {
        public readonly T key;

        public readonly IState state;

        public StateEntry(T key, IState state)
        {
            this.key = key;
            this.state = state;
        }
    }
}