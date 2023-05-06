using System;

namespace Numerics
{
    public class ChangablePublisher<T> : IChangingPublisher<T>, IChangable<T>
    {
        private readonly IChangable<T> _changable;

        public T Value => throw new NotImplementedException();

        public event Action<T> IncreasedBy;
        public event Action<T> DecreasedBy;

        public ChangablePublisher(IChangable<T> changable)
        {
            if (changable == this)
                throw new ArgumentException(nameof(changable));

            _changable = changable;
        }

        public void Add(T addableValue)
        {
            _changable.Add(addableValue);
            IncreasedBy?.Invoke(addableValue);
        }

        public bool CanSubtract(T subtractValue)
        {
            return _changable.CanSubtract(subtractValue);
        }

        public bool TrySubtract(T subtractValue)
        {
            if (_changable.TrySubtract(subtractValue) == false)
                return false;

            DecreasedBy?.Invoke(subtractValue);
            return true;
        }
    }
}
