using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using System;

namespace Tests.Mock
{
    public class ResourceMock : IResource
    {
        public Currency Currency => throw new NotImplementedException();

        public int Value => throw new NotImplementedException();

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