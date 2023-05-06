using Goods.Model.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Goods.Model
{
    public class Storage : IStorage
    {
        private readonly IEnumerable<IResource> _resources;

        public IEnumerable<IResource> Resources => _resources;


        public Storage(IEnumerable<IResource> resources)
        {
            if (resources == null)
                throw new ArgumentNullException(nameof(resources));

            if (resources.GroupBy(resource => resource.Currency).Any(group => group.Count() > 1))
                throw new Exception($"There are resources with the same currency");

            _resources = resources;
        }

        public int GetValue(Currency currency)
        {
            if (TryFindResource(currency, out IResource resource))
                return resource.Value;

            return 0;
        }

        public bool TryAdd(Currency currency, int addableAmount)
        {
            if (TryFindResource(currency, out IResource resource))
            {
                resource.Add(addableAmount);
                return true;
            }

            return false;
        }

        public bool TrySpend(Currency currency, int spendableAmount)
        {
            return TryFindResource(currency, out IResource resource)
                   && resource.TrySubtract(spendableAmount);
        }

        public bool CanSpend(Currency currency, int spendableAmount)
        {
            if (TryFindResource(currency, out IResource resource))
                return resource.CanSubtract(spendableAmount);

            return false;
        }

        private bool TryFindResource(Currency currency, out IResource foundResource)
        {
            foundResource = Resources.FirstOrDefault(resource => resource.Currency == currency);
            return foundResource != null;
        }
    }
}