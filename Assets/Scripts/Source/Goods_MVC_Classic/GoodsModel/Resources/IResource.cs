using System;
using Numerics;

namespace Goods.Model.Resources
{
    public interface IResource : INaturalNumber, IChangingPublisher<int>
    {
        public Currency Currency { get; }
    }
}