using Clients.Model.Configs;
using Deals.Model;
using System;
using UnityEngine;
using Zenject;

namespace Clients.Adapter
{
    public class TradingPipeline : IDisposable, IDealPublisher, IClientChangingPubliser
    {
        private IClientsSequence _clientsSequence;
        private IDealCreator _dealCreator;
        private IDeal _deal;
        private IClient _client;

        public event Action<string> ClientChosen;
        public event Action<IDeal> DealCreated;
        public event Action DealRejected;
        public event Action DealAccepted;

        [Inject]
        private void Construct(IDealCreator dealCreator, IClientsSequence clientsSequence)
        {
            _clientsSequence = clientsSequence;
            _dealCreator = dealCreator;

            _clientsSequence.ClientsGotReady += OnClientsGotReady;
        }

        public bool TryGetClientName(out string clientName)
        {
            clientName = null;
            if (_client == null)
                return false;

            clientName = _client.Name;
            return true;
        }

        public void Dispose()
        {
            TryUnsubscribeFromDeal();
            _clientsSequence.ClientsGotReady -= OnClientsGotReady;
        }

        public bool TryGetDeal(out IDeal deal)
        {
            deal = _deal;
            if (_deal == null)
                return false;

            return true;
        }

        private void OnDealRejected()
        {
            DealRejected?.Invoke();
            UpdateClient();
        }

        private void OnDealAccepted()
        {
            DealAccepted?.Invoke();
            UpdateClient();
        }

        private bool TryFindClient()
        {
            if (_clientsSequence.TryGetNext(out _client) == false)
            {
                Debug.LogError("Cannot find new client");
                return false;
            }

            return true;
        }

        private void UpdateClient()
        {
            if (TryFindClient() == false)
                return;

            ClientChosen?.Invoke(_client.Name);
            IDeal newDeal = _dealCreator.CreateDeal(_client);
            TryUnsubscribeFromDeal();
            _deal = newDeal;
            SubscribeToDeal();
            DealCreated?.Invoke(_deal);
        }

        private void SubscribeToDeal()
        {
            _deal.Accepted += OnDealAccepted;
            _deal.Rejected += OnDealRejected;
        }

        private bool TryUnsubscribeFromDeal()
        {
            if (_deal == null)
                return false;

            _deal.Accepted -= OnDealAccepted;
            _deal.Rejected -= OnDealRejected;
            return true;
        }

        private void OnClientsGotReady()
        {
            UpdateClient();
        }
    }
}