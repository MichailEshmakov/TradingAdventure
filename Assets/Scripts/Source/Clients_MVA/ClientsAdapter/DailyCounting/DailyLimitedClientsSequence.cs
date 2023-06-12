using Clients.Model.Configs;
using System;
using Zenject;

namespace Clients.Adapter.DailyCounting
{
    public class DailyLimitedClientsSequence : IClientsSequence, IDisposable
    {
        private IMainClientsSequence _sequence;
        private IReadonlyClientsDailyCounter _dailyCounter;

        public event Action ClientsGotReady;

        [Inject]
        private void Construct(IMainClientsSequence sequence, IReadonlyClientsDailyCounter dailyCounter)
        {
            _sequence = sequence;
            _dailyCounter = dailyCounter;
            _sequence.ClientsGotReady += OnClientsGotReady;
        }

        public bool TryGetNext(out IClient client)
        {
            client = null;
            if (_dailyCounter.IsEnough())
                return false;

            return _sequence.TryGetNext(out client);
        }

        public void Dispose()
        {
            if (_sequence != null)
                _sequence.ClientsGotReady -= OnClientsGotReady;
        }

        private void OnClientsGotReady()
        {
            ClientsGotReady?.Invoke();
        }
    }
}