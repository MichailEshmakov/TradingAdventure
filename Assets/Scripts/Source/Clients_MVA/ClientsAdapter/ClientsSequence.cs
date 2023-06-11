using Clients.Model.Configs;
using Days.Model;
using Days.Model.Alternation;
using Extensions;
using System;
using System.Collections.Generic;
using Zenject;

namespace Clients.Adapter
{
    public class ClientsSequence : IClientsSequence, IDisposable
    {
        private IAllClients _allClients;
        private IReadonlyDaySettings _daySettings;
        private IDayStartingPublisher _dayStartingPublisher;
        private IEnumerable<IClient> _currentClients;

        public event Action ClientsGotReady;

        [Inject]
        private void Construct(IAllClients allClients, IReadonlyDaySettings daySettings, IDayStartingPublisher dayStartingPublisher)
        {
            _allClients = allClients;
            _daySettings = daySettings;
            _dayStartingPublisher = dayStartingPublisher;
            _dayStartingPublisher.NextDayStarted += OnNextDayStarted;
        }

        public bool TryGetNext(out IClient nextClient)
        {
            if (_currentClients.TryGetRandom(out nextClient) == false)
                return false;
            
            return true;
        }

        public void Dispose()
        {
            _dayStartingPublisher.NextDayStarted -= OnNextDayStarted;
        }

        private void OnNextDayStarted()
        {
            _currentClients = _allClients.Take(_daySettings.ClientsTypesAmount);
            ClientsGotReady?.Invoke();
        }
    }
}