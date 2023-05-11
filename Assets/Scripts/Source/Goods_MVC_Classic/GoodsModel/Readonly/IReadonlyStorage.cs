using Goods.Model.Readonly.Resources;
using System.Collections.Generic;

namespace Goods.Model.Readonly
{
    public interface IReadonlyStorage
    {
        IEnumerable<IReadonlyResource> Resources { get; }

        public int GetValue(Currency currency);
        public bool CanSpend(Currency currency, int spendableAmount);
        public bool CanStore(Currency currency);
        public bool TryFindResource(Currency currency, out IReadonlyResource foundResource);
        public bool TryGetFirstResource(out IReadonlyResource resource);
    }
}