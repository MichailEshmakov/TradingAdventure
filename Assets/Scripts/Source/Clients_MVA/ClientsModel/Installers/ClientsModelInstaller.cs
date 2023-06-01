using Clients.Model.Configs;
using UnityEngine;
using Zenject;

namespace Clients.Model.Installers
{
    public class ClientsModelInstaller : MonoInstaller
    {
        [SerializeField] private AllClients _allClients;

        public override void InstallBindings()
        {
            Container.Bind<IAllClients>().FromInstance(_allClients).AsSingle();
        }
    }
}
