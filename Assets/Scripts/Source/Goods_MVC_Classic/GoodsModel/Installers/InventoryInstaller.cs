using Goods.Model.Configs;
using Goods.Model.Readonly;
using UnityEngine;
using Zenject;

namespace Goods.Model.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig _startResourcesConfig;
        [SerializeField] private BasicPricesConfig _pricesConfig;

        public override void InstallBindings()
        {
            Storage storage = new Storage(_startResourcesConfig.Resources);
            Container.Bind<IStorage>().FromInstance(storage).AsSingle();
            Container.Bind<IReadonlyStorage>().FromInstance(storage).AsSingle();

            if (_pricesConfig != null)
                Container.Bind<IBasicPricesConfig>().FromInstance(_pricesConfig).AsSingle();
            else
                Debug.LogWarning($"There is no {nameof(_pricesConfig)}");
        }
    }
}