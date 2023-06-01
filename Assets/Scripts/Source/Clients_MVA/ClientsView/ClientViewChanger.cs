using Clients.Adapter;
using Clients.View.Configs;
using System;
using UnityEngine;
using Zenject;

namespace Clients.View
{
    public class ClientViewChanger : IDisposable
    {
        private IClientView _view;
        private IClientChangingPubliser _clientChangingPubliser;
        private IDealPublisher _dealPublisher;
        private IAllClientsViewConfigs _allClientViewConfigs;

        [Inject]
        private void Consruct(IClientView view, 
            IClientChangingPubliser clientChangingPubliser, 
            IDealPublisher dealPublisher, 
            IAllClientsViewConfigs allClientsViews)
        {
            _view = view;
            _clientChangingPubliser = clientChangingPubliser;
            _dealPublisher = dealPublisher;
            _allClientViewConfigs = allClientsViews;

            _clientChangingPubliser.ClientChosen += OnClientChosen;
            _dealPublisher.DealAccepted += OnDealAccepted;
            _dealPublisher.DealRejected += DealRejected;

            if (_clientChangingPubliser.TryGetClientName(out string clientName))
                TryRepresentClient(clientName);
        }

        public void Dispose()
        {
            _clientChangingPubliser.ClientChosen -= OnClientChosen;
            _dealPublisher.DealAccepted -= OnDealAccepted;
            _dealPublisher.DealRejected -= DealRejected;
        }

        private void DealRejected()
        {
            _view.Hide();
        }

        private void OnDealAccepted()
        {
            _view.Hide();
        }

        private void OnClientChosen(string clientName)
        {
            TryRepresentClient(clientName);
        }

        private bool TryRepresentClient(string clientName)
        {
            if (_allClientViewConfigs.TryFind(clientName, out ClientViewConfig clientViewConfig) == false)
            {
                Debug.LogError($"Cannot find {clientName} in {nameof(_allClientViewConfigs)}");
                if (_allClientViewConfigs.TryGetRandom(out clientViewConfig) == false)
                    return false;
            }

            _view.Show();
            _view.Init(clientViewConfig);
            return true;
        }
    }
}