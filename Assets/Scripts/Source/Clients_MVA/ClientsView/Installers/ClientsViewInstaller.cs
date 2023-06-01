using Clients.View.Configs;
using UnityEngine;
using Zenject;

namespace Clients.View.Installers
{
    public class ClientsViewInstaller : MonoInstaller, IInitializable
    {
        private ClientViewChanger _clientViewChanger;

        [SerializeField] private AllClientsViews _allClientsViewConfigs;
        [SerializeField] private ClientView _clientView;

        private void OnValidate()
        {
            if (_clientView == null)
                _clientView = FindObjectOfType<ClientView>();
        }

        private void OnDisable()
        {
            if (_clientViewChanger != null)
                _clientViewChanger.Dispose();
        }

        public override void InstallBindings()
        {
            Container.Bind<IAllClientsViewConfigs>().FromInstance(_allClientsViewConfigs);
            Container.Bind<IClientView>().FromInstance(_clientView);
            Container.BindInterfacesTo<ClientsViewInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _clientViewChanger = Container.Instantiate<ClientViewChanger>();
        }
    }
}