using Goods.Model.Readonly.Resources;
using Numerics;

namespace Goods.Model.Resources
{
    public interface IResource : INaturalNumber, IReadonlyResource
    {
    }
}