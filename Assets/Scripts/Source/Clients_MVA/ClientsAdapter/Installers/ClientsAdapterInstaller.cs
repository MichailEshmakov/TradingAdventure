using Clients.Adapter.DealCostChanging;
using Zenject;

namespace Clients.Adapter.Installers
{
    public class ClientsAdapterInstaller : MonoInstaller, IInitializable
    {
        private TradingPipeline _tradingPipeline;
        private ClientsSequence _clientsSequence;

        private void OnDisable()
        {
            if (_tradingPipeline != null)
                _tradingPipeline.Dispose();

            if (_clientsSequence != null)
                _clientsSequence.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealCreator>().To<CostChangableDealCreator>().AsSingle();
            Container.Bind<IDealCostCoefficient>().To<DailyDealCostCoefficient>().AsSingle();
            Container.Bind(typeof(IDealPublisher), typeof(IClientChangingPubliser)).To<TradingPipeline>().AsSingle();
            Container.Bind<IClientsSequence>().To<ClientsSequence>().AsSingle();
            Container.BindInterfacesTo<ClientsAdapterInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _tradingPipeline = (TradingPipeline)Container.Resolve<IDealPublisher>();
            _clientsSequence = (ClientsSequence)Container.Resolve<IClientsSequence>();
        }
    }
}