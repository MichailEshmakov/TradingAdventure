using Goods.Model;

namespace Tests.Mock
{
    public class PriceCoefficientMock : IPriceCoefficient
    {
        private readonly float _value;

        public PriceCoefficientMock(float value)
        {
            _value = value;
        }

        public float Value => _value;
    }
}