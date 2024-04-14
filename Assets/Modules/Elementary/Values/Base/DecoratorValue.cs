namespace Elementary
{
    public sealed class DecoratorValue<T> : IValue<T>
    {
        public T Current
        {
            get { return this.value.Current; }
        }

        private readonly IValue<T> value;

        public DecoratorValue(IValue<T> value)
        {
            this.value = value;
        }
    }
}