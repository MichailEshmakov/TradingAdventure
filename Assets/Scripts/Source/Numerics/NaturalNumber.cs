using System;

namespace Numerics
{
    public class NaturalNumber : INaturalNumber
    {
        private int _value;

        public int Value => _value;

        public NaturalNumber(int value = 0)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = value;
        }

        public void Add(int addableValue)
        {
            if (addableValue < 0)
                throw new ArgumentOutOfRangeException(nameof(addableValue));

            int previousValue = _value;
            _value += addableValue;
            if (previousValue > _value)
                _value = int.MaxValue;
        }

        public bool CanSubtract(int subtractValue)
        {
            if (subtractValue < 0)
                throw new ArgumentOutOfRangeException(nameof(subtractValue));

            return _value >= subtractValue;
        }

        public bool TrySubtract(int subtractValue)
        {
            if (CanSubtract(subtractValue) == false)
                return false;

            _value -= subtractValue;
            return true;
        }
    }
}