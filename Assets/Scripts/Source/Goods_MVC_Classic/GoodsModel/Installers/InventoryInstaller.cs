using Goods.Model.Configs;
using Goods.Model.Readonly;
using Goods.Model.Resources;
using Goods.Model.Saving;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Goods.Model.Installers
{
    public class InventoryInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig _startResourcesConfig;
        [SerializeField] private BasicPricesConfig _pricesConfig;

        private InventorySaver _inventorySaver;

        private void OnDestroy()
        {
            if (_inventorySaver != null)
                _inventorySaver.Dispose();
        }

        public override void InstallBindings()
        {
            KeyFormer keyFormer = new KeyFormer(SavingKeys.InventoryResource);
            IEnumerable<IResource> resources = FormResources(keyFormer);
            _inventorySaver = new InventorySaver(resources, keyFormer);

            Storage storage = new Storage(resources);
            Container.Bind<IStorage>().FromInstance(storage).AsSingle();
            Container.Bind<IReadonlyStorage>().FromInstance(storage).AsSingle();

            if (_pricesConfig != null)
                Container.Bind<IBasicPricesConfig>().FromInstance(_pricesConfig).AsSingle();
            else
                Debug.LogWarning($"There is no {nameof(_pricesConfig)}");
        }

        private IEnumerable<IResource> FormResources(KeyFormer keyFormer)
        {
            InventoryLoader inventoryLoader = new InventoryLoader(keyFormer);
            IList<IResource> result = new List<IResource>();
            foreach (IResource configResource in _startResourcesConfig.Resources)
            {
                if (inventoryLoader.HasKey(configResource.Currency))
                    result.Add(new Resource(inventoryLoader.Load(configResource.Currency), configResource.Currency));
                else
                    result.Add(configResource);
            }

            return result;
        }
    }
}