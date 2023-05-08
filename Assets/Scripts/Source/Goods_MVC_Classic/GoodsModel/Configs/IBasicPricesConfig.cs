using Goods.Model.Readonly.Resources;

namespace Goods.Model.Configs
{
    public interface IBasicPricesConfig
    {
        public bool TryFindPrice(Currency currency, out float price);
    }
}