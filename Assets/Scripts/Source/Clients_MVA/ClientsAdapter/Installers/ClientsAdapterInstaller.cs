using Zenject;

namespace Clients.Adapter.Installers
{
    public class ClientsAdapterInstaller : MonoInstaller, IInitializable
    {
        private TradingPipeline _tradingPipeline;

        private void OnDisable()
        {
            if (_tradingPipeline != null)
                _tradingPipeline.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealCreator>().To<DealCreator>().AsSingle();
            Container.Bind(typeof(IDealPublisher), typeof(IClientChangingPubliser)).To<TradingPipeline>().AsSingle();
            Container.BindInterfacesTo<ClientsAdapterInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _tradingPipeline = (TradingPipeline)Container.Resolve<IDealPublisher>();
        }
    }
}