using System;

namespace Numerics
{
    public interface IChangingPublisher<T>
    {
        public event Action<T> IncreasedBy;
        public event Action<T> DecreasedBy;
    }
}