using Clients.Adapter.DailyCounting;
using Clients.Adapter.DealCostChanging;
using Zenject;

namespace Clients.Adapter.Installers
{
    public class ClientsAdapterInstaller : MonoInstaller, IInitializable
    {
        private TradingPipeline _tradingPipeline;
        private ClientsSequence _clientsSequence;
        private DailyLimitedClientsSequence _dailyLimitedClientsSequence;

        private void OnDisable()
        {
            if (_tradingPipeline != null)
                _tradingPipeline.Dispose();

            if (_clientsSequence != null)
                _clientsSequence.Dispose();

            if (_dailyLimitedClientsSequence != null)
                _dailyLimitedClientsSequence.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealCreator>().To<CostChangableDealCreator>().AsSingle();
            Container.Bind<IDealCostCoefficient>().To<DailyDealCostCoefficient>().AsSingle();
            Container.Bind(typeof(IDealPublisher), typeof(IClientChangingPubliser)).To<TradingPipeline>().AsSingle();
            Container.Bind<IMainClientsSequence>().To<ClientsSequence>().AsSingle();
            Container.Bind<IClientsSequence>().To<DailyLimitedClientsSequence>().AsSingle();
            Container.BindInterfacesTo<ClientsAdapterInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _tradingPipeline = (TradingPipeline)Container.Resolve<IDealPublisher>();
            _clientsSequence = (ClientsSequence)Container.Resolve<IMainClientsSequence>();
            _dailyLimitedClientsSequence = (DailyLimitedClientsSequence)Container.Resolve<IClientsSequence>();
        }
    }
}