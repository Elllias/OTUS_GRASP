namespace AI.Iterators
{
    public sealed class OnceIterator<T> : Iterator<T>
    {
        public OnceIterator(T[] moveItems) : base(moveItems)
        {
        }

        public override bool MoveNext()
        {
            if (this.pointer + 1 < this.movePoints.Length)
            {
                this.pointer++;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            this.pointer = 0;
        }

        public override void Dispose()
        {
        }
    }
}