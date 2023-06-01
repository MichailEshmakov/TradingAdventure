using Goods.Model.Configs;
using Goods.Model.Readonly;
using Goods.Model.Resources;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Goods.Model.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private InventoryConfig _config;
        [SerializeField] private BasicPricesConfig _pricesConfig;

        public override void InstallBindings()
        {
            List<IResource> resources = new List<IResource>();
            foreach (CurrencyIntPair currencyValue in _config.StartPlayersResources)
            {
                resources.Add(new Resource(currencyValue.Value, currencyValue.Currency));
            }

            Storage storage = new Storage(resources);
            Container.Bind<IStorage>().FromInstance(storage).AsSingle();
            Container.Bind<IReadonlyStorage>().FromInstance(storage).AsSingle();

            if (_pricesConfig != null)
                Container.Bind<IBasicPricesConfig>().FromInstance(_pricesConfig).AsSingle();
            else
                Debug.LogWarning($"There is no {nameof(_pricesConfig)}");
        }
    }
}