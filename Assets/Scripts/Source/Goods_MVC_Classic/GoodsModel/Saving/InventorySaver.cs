using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Goods.Model.Saving
{
    public class InventorySaver : IDisposable
    {
        private readonly IDictionary<Currency, ResourceSaver> _resourceSavers;

        public InventorySaver(IEnumerable<IReadonlyResource> resources, IKeyFormer keyFormer)
        {
            _resourceSavers = new Dictionary<Currency, ResourceSaver>(resources.Count());
            foreach (IReadonlyResource resource in resources)
            {
                _resourceSavers.Add(resource.Currency, new ResourceSaver(keyFormer, resource));
            }
        }

        public void Dispose()
        {
            foreach (ResourceSaver resourceSaver in _resourceSavers.Values)
            {
                resourceSaver.Dispose();
            }
        }
    }
}