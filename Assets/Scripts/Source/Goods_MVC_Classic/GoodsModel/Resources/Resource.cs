using System;
using Goods.Model.Readonly.Resources;
using Numerics;

namespace Goods.Model.Resources
{
    public class Resource : IResource
    {
        private readonly INaturalNumber _value;
        private readonly Currency _currency;

        public event Action<int> IncreasedBy;
        public event Action<int> DecreasedBy;

        public Currency Currency => _currency;
        public int Value => _value.Value;

        public Resource(INaturalNumber value, Currency currency)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _currency = currency;
        }

        public Resource(int value, Currency currency)
        {
            _value = new NaturalNumber(value);
            _currency = currency;
        }

        public void Add(int addableValue)
        {
            _value.Add(addableValue);
            IncreasedBy?.Invoke(addableValue);
        }

        public bool CanSubtract(int subtractValue)
        {
            return _value.CanSubtract(subtractValue);
        }

        public bool TrySubtract(int subtractValue)
        {
            if (_value.TrySubtract(subtractValue) == false)
                return false;

            DecreasedBy?.Invoke(subtractValue);
            return true;
        }
    }
}