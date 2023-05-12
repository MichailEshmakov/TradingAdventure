using Goods.Model.Readonly.Resources;
using System;

namespace Deals.Model
{
    public interface IReadonlyDeal
    {
        public event Action Rejected;
        public event Action Accepted;

        public IReadonlyResource Removable { get; }
        public IReadonlyResource Addable { get; }

        public bool CanAccept();
    }
}