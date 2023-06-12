using Days.Model;
using Days.Model.Alternation;
using System;
using Zenject;

namespace Clients.Adapter.DailyCounting
{
    public class ClientsDailyCounter : IClientsDailyCounter, IDisposable
    {
        private IDayStartingPublisher _dayStartingPublisher;
        private IReadonlyDaySettings _daySettings;
        private int _servedClients;

        public event Action AllClientsServed;

        [Inject]
        private void Construct(IDayStartingPublisher dayStartingPublisher, IReadonlyDaySettings daySettings)
        {
            _dayStartingPublisher = dayStartingPublisher;
            _daySettings = daySettings;

            _dayStartingPublisher.NextDayStarted += OnNextDayStarted;
        }

        public bool IsEnough()
        {
            return _servedClients >= _daySettings.ClientsAmount;
        }

        public void AddOne()
        {
            if (IsEnough() == false)
                _servedClients++;

            if (IsEnough())
                AllClientsServed?.Invoke();
        }

        public void Dispose()
        {
            _dayStartingPublisher.NextDayStarted -= OnNextDayStarted;
        }

        private void OnNextDayStarted()
        {
            _servedClients = 0;
        }
    }
}
