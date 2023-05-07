using Numerics;

namespace Goods.Model.Readonly.Resources
{
    public interface IReadonlyResource : IChangingPublisher<int>
    {
        public int Value { get; }
        public Currency Currency { get; }
    }
}