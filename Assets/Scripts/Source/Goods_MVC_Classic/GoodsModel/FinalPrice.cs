using System.Collections.Generic;

namespace Goods.Model
{
    public class FinalPrice : IFinalPrice
    {
        private readonly float _basicValue;
        private readonly HashSet<IPriceCoefficient> _coefficients = new HashSet<IPriceCoefficient>();

        public FinalPrice(float basicValue)
        {
            _basicValue = basicValue;
        }

        public bool TryAddCoefficient(IPriceCoefficient coefficient)
        {
            return _coefficients.Add(coefficient);
        }

        public bool TryRemoveCoefficient(IPriceCoefficient coefficient)
        {
            return _coefficients.Remove(coefficient);
        }

        public float ComputeValue()
        {
            float value = _basicValue;
            foreach (IPriceCoefficient _coefficients in _coefficients)
            {
                value *= _coefficients.Value;
            }

            return value;
        }
    }
}