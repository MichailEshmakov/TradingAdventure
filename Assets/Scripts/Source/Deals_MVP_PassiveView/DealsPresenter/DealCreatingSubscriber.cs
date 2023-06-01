using Clients.Adapter;
using Deals.Model;
using System;
using Zenject;

namespace Deals.Presenter
{
    public class DealCreatingSubscriber : IDisposable
    {
        private IDealPresenter _dealPresenter;
        private IDealPublisher _dealPublisher;

        [Inject]
        private void Construct(IDealPresenter dealPresenter, IDealPublisher dealPublisher)
        {
            _dealPresenter = dealPresenter;
            _dealPublisher = dealPublisher;

            _dealPublisher.DealCreated += OnDealCreated;
            if (_dealPublisher.TryGetDeal(out IDeal deal))
                RepresentDeal(deal);
        }

        public void Dispose()
        {
            _dealPublisher.DealCreated -= OnDealCreated;
        }

        private void OnDealCreated(IDeal deal)
        {
            RepresentDeal(deal);
        }

        private void RepresentDeal(IDeal deal)
        {
            _dealPresenter.Represent(deal);
        }
    }
}