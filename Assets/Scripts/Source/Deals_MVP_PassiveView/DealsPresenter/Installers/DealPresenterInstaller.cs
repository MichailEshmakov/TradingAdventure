using Zenject;

namespace Deals.Presenter.Installers
{
    public class DealPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IDealPresenter>().To<DealPresenter>().AsSingle();
        }

        private void OnDestroy()
        {
            (Container.Resolve<IDealPresenter>() as DealPresenter).Dispose();
        }
    }
}