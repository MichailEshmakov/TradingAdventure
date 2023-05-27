using Goods.Model.Readonly.Resources;
using NaughtyAttributes;
using System;
using UnityEngine;

namespace Clients.Model.Configs
{
    [Serializable]
    public class ClientPreference : IResourceCoefficients
    {
        [SerializeField] private Currency _currency;
        [SerializeField] [MinMaxSlider(0.25f, 3f)] private Vector2 _demandCoefficients;
        [SerializeField] [MinMaxSlider(0.25f, 3f)] private Vector2 _supplyCoefficients;
        [SerializeField] [Range(0f, 1f)] private float _demandChance;
        [SerializeField] [Range(0f, 1f)] private float _supplyChance;

        public Currency Currency => _currency;
        public float MinDemandCoefficient => _demandCoefficients.x;
        public float MaxDemandCoefficient => _demandCoefficients.y;
        public float MinSupplyCoefficient => _supplyCoefficients.x;
        public float MaxSupplyCoefficient => _supplyCoefficients.y;
        public float DemandChance => _demandChance;
        public float SupplyChance => _supplyChance;

        public ClientPreference(Currency currency, 
            Vector2 demandCoefficients, 
            Vector2 supplyCoefficients, 
            float demandChance, 
            float supplyChance)
        {
            _currency = currency;
            _demandCoefficients = demandCoefficients;
            _supplyCoefficients = supplyCoefficients;
            _demandChance = demandChance;
            _supplyChance = supplyChance;
        }
    }
}
