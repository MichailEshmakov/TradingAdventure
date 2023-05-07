using Goods.Model.Readonly;
using Goods.Model.Readonly.Resources;

namespace Goods.Model
{
    public interface IStorage : IReadonlyStorage
    {
        public bool TryAdd(Currency currency, int addableAmount);
        public bool TrySpend(Currency currency, int spendableAmount);
    }
}