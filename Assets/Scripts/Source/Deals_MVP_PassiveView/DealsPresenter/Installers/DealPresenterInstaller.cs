using Zenject;

namespace Deals.Presenter.Installers
{
    public class DealPresenterInstaller : MonoInstaller, IInitializable
    {
        private DealCreatingSubscriber _creatingSubscriber;

        private void OnDestroy()
        {
            (Container.Resolve<IDealPresenter>() as DealPresenter).Dispose();

            if (_creatingSubscriber != null)
                _creatingSubscriber.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IDealPresenter>().To<DealPresenter>().AsSingle();
            Container.BindInterfacesTo<DealPresenterInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _creatingSubscriber = Container.Instantiate<DealCreatingSubscriber>();
        }
    }
}