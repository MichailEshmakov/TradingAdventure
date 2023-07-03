using Goods.Model.Readonly.Resources;

namespace Goods.Model.Saving
{
    public class KeyFormer : IKeyFormer
    {
        private string _basicKey;

        public KeyFormer(string basicKey)
        {
            _basicKey = basicKey;
        }

        public string FormKey(Currency currency)
        {
            return $"{_basicKey}_{currency}";
        }
    }
}