namespace Numerics
{
    public interface IChangable<T>
    {
        public T Value { get; }

        public void Add(T addableValue);
        public bool CanSubtract(T subtractValue);
        public bool TrySubtract(T subtractValue);
    }
}