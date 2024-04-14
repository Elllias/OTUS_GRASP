namespace Elementary
{
    public sealed class Condition : ICondition
    {
        private readonly bool isTrue;

        public Condition(bool isTrue)
        {
            this.isTrue = isTrue;
        }

        public bool IsTrue()
        {
            return this.isTrue;
        }
    }
}
