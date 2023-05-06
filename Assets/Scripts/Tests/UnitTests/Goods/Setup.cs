using Goods.Model;
using Goods.Model.Resources;
using Tests.Mock;

namespace Tests.UnitTests.Goods
{
    public static class Setup
    {
        public static FinalPrice FinalPrice(float basicPrice, params float[] coefficients)
        {
            FinalPrice finalPrice = new FinalPrice(basicPrice);

            foreach (float coefficient in coefficients)
            {
                IPriceCoefficient coefficientObject = new PriceCoefficientMock(coefficient);
                finalPrice.TryAddCoefficient(coefficientObject);
            }

            return finalPrice;
        }

        public static Storage Storage(params IResource[] resources)
        {
            return new Storage(resources);
        }
    }
}