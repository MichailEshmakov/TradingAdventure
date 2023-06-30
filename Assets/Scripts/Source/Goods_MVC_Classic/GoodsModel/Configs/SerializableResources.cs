using Goods.Model.Resources;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Goods.Model.Configs
{
    [Serializable]
    public class SerializableResources
    {
        [SerializeField] private List<CurrencyIntPair> _resources;

        public IEnumerable<IResource> FormResources()
        {
            return _resources
                .Select(currencyValue => new Resource(currencyValue.Value, currencyValue.Currency))
                .ToList();
        }
    }
}