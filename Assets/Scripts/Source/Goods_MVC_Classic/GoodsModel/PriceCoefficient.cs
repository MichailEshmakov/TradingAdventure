namespace Goods.Model
{
    public class PriceCoefficient : IPriceCoefficient
    {
        private readonly float _value;

        public PriceCoefficient(float value)
        {
            _value = value;
        }

        public float Value => _value;
    }
}