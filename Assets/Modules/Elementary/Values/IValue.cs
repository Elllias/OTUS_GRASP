namespace Elementary
{
    public interface IValue<out T>
    {
        T Current { get; }
    }
}