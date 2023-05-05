namespace Goods.Model
{
    public interface IFinalPrice
    {
        public bool TryAddCoefficient(IPriceCoefficient coefficient);
        public bool TryRemoveCoefficient(IPriceCoefficient coefficient);
        public float ComputeValue();
    }
}