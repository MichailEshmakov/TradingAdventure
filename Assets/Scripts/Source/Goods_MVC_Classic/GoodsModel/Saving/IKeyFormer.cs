using Goods.Model.Readonly.Resources;

namespace Goods.Model.Saving
{
    public interface IKeyFormer
    {
        public string FormKey(Currency currency);
    }
}