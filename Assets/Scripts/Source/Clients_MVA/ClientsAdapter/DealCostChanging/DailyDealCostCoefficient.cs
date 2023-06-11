using Days.Model;
using Zenject;

namespace Clients.Adapter.DealCostChanging
{
    public class DailyDealCostCoefficient : IDealCostCoefficient
    {
        private IReadonlyDaySettings _daySettings;

        public float Value => _daySettings.DealsCostCoefficient;

        [Inject]
        private void Construct(IReadonlyDaySettings daySettings)
        {
            _daySettings = daySettings;
        }
    }
}