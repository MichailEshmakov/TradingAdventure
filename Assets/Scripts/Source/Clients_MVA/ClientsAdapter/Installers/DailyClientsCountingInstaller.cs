using Clients.Adapter.DailyCounting;
using Zenject;

namespace Clients.Adapter.Installers
{
    public class DailyClientsCountingInstaller : MonoInstaller, IInitializable
    {
        private ClientsDailyCounter _clientsDailyCounter;
        private DailyCounterUpdater _dailyCounterUpdater;

        private void OnDestroy()
        {
            _clientsDailyCounter.Dispose();
            _dailyCounterUpdater.Dispose();
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DailyClientsCountingInstaller>().FromInstance(this).AsSingle();
            Container.Bind(typeof(IClientsDailyCounter), typeof(IReadonlyClientsDailyCounter)).To<ClientsDailyCounter>().AsSingle();
        }

        public void Initialize()
        {
            _clientsDailyCounter = (ClientsDailyCounter)Container.Resolve<IClientsDailyCounter>();
            _dailyCounterUpdater = Container.Instantiate<DailyCounterUpdater>();
        }
    }
}
