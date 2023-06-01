using Deals.Model;
using System;

namespace Clients.Adapter
{
    public interface IDealPublisher
    {
        public event Action<IDeal> DealCreated;
        public event Action DealRejected;
        public event Action DealAccepted;

        public bool TryGetDeal(out IDeal deal);
    }
}