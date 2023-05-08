using System.Collections.Generic;

namespace Goods.Model
{
    public interface IFinalPrice
    {
        public IEnumerable<IPriceCoefficient> Coefficients { get; }

        public bool TryAddCoefficient(IPriceCoefficient coefficient);
        public bool TryRemoveCoefficient(IPriceCoefficient coefficient);
        public float ComputeValue();
    }
}