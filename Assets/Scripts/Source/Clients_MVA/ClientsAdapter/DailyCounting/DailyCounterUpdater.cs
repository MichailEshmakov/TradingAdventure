using System;
using Zenject;

namespace Clients.Adapter.DailyCounting
{
    public class DailyCounterUpdater : IDisposable
    {
        private IDealPublisher _dealPublisher;
        private IClientsDailyCounter _counter;

        [Inject]
        private void Construct(IDealPublisher dealPublisher, IClientsDailyCounter counter)
        {
            _dealPublisher = dealPublisher;
            _counter = counter;

            _dealPublisher.DealAccepted += OnDealAccepted;
            _dealPublisher.DealRejected += OnDealRejected;
        }

        public void Dispose()
        {
            _dealPublisher.DealAccepted -= OnDealAccepted;
            _dealPublisher.DealRejected -= OnDealRejected;
        }

        private void OnDealRejected()
        {
            _counter.AddOne();
        }

        private void OnDealAccepted()
        {
            _counter.AddOne();
        }
    }
}