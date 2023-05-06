using Goods.Model.Resources;
using System.Collections.Generic;

namespace Goods.Model
{
    public interface IStorage
    {
        IEnumerable<IResource> Resources { get; }

        public int GetValue(Currency currency);
        public bool TryAdd(Currency currency, int addableAmount);
        public bool TrySpend(Currency currency, int spendableAmount);
        public bool CanSpend(Currency currency, int spendableAmount);
    }
}