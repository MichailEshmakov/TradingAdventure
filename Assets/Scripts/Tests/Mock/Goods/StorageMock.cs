using Goods.Model;
using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;

namespace Tests.Mock.Goods
{
    public class StorageMock : IStorage
    {
        private readonly IDictionary<Currency, int> _resources = new Dictionary<Currency, int>();

        public IEnumerable<IReadonlyResource> Resources => throw new NotImplementedException();

        public StorageMock(bool isFull)
        {
            int value = isFull ? int.MaxValue : 0;
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                _resources.Add(currency, value);
            }
        }

        public bool CanSpend(Currency currency, int spendableAmount)
        {
            return _resources[currency] >= spendableAmount;
        }

        public bool CanStore(Currency currency) => true;

        public int GetValue(Currency currency) => _resources[currency];

        public bool TryAdd(Currency currency, int addableAmount)
        {
            throw new NotImplementedException();
        }

        public bool TryFindResource(Currency currency, out IReadonlyResource foundResource)
        {
            throw new NotImplementedException();
        }

        public bool TryGetFirstResource(out IReadonlyResource resource)
        {
            throw new NotImplementedException();
        }

        public bool TrySpend(Currency currency, int spendableAmount)
        {
            if (CanSpend(currency, spendableAmount) == false)
                return false;

            _resources[currency] -= spendableAmount;
            return true;
        }
    }
}
