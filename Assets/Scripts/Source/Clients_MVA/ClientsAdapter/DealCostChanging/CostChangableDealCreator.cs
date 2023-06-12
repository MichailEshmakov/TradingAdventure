using Clients.Model.Configs;
using Deals.Model;
using Goods.Model;
using Goods.Model.Configs;
using Goods.Model.Resources;
using UnityEngine;
using Zenject;

namespace Clients.Adapter.DealCostChanging
{
    public class CostChangableDealCreator : IDealCreator
    {
        private IDealCreator _dealCreator;
        private IDealCostCoefficient _dealCostCoefficient;
        private IStorage _playerInventory;

        [Inject]
        private void Construct(IBasicPricesConfig config, IStorage playerInventory, IDealCostCoefficient dealCostCoefficient)
        {
            _dealCreator = new DealCreator(config, playerInventory);
            _dealCostCoefficient = dealCostCoefficient;
            _playerInventory = playerInventory;
        }
            
        public IDeal CreateDeal(IClient client)
        {
            IDeal deal = _dealCreator.CreateDeal(client);
            IResource addable = new Resource(Mathf.CeilToInt(deal.Addable.Value * _dealCostCoefficient.Value), deal.Addable.Currency);
            IResource removable = new Resource(Mathf.CeilToInt(deal.Removable.Value * _dealCostCoefficient.Value), deal.Removable.Currency);
            return new Deal(removable, addable, _playerInventory);
        }
    }
}