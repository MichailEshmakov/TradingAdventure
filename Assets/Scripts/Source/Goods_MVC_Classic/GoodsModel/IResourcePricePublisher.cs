using Goods.Model.Readonly;
using Goods.Model.Readonly.Resources;

namespace Goods.Model
{
    public interface IResourcePricePublisher : IReadonlyResourcePricePublisher
    {
        public bool TryAddCoefficient(IPriceCoefficient coefficient);
        public bool TryRemoveCoefficient(IPriceCoefficient coefficient);
        public void SetResource(IReadonlyResource resource);
    }
}