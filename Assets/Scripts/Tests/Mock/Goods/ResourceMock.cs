using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using System;

namespace Tests.Mock
{
    public class ResourceMock : IResource
    {
        public Currency Currency { get; set; }

        public int Value { get; set; }

        public ResourceMock(Currency currency = 0, int value = 0)
        {
            Currency = currency;
            Value = value;
        }

        public event Action<int> IncreasedBy;
        public event Action<int> DecreasedBy;

        public void Add(int addableValue)
        {
            throw new NotImplementedException();
        }

        public bool CanSubtract(int subtractValue)
        {
            throw new NotImplementedException();
        }

        public bool TrySubtract(int subtractValue)
        {
            throw new NotImplementedException();
        }
    }
}