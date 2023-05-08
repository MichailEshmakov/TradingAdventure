using System;

namespace Goods.Model.Readonly
{
    public interface IReadonlyResourcePricePublisher
    {
        public event Action PriceChanged;

        public float ComputePrice();
    }
}