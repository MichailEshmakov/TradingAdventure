using Deals.Model;
using Deals.View.Development;
using Goods.Model;
using Goods.Model.Readonly.Resources;
using Goods.Model.Resources;
using UnityEngine;
using Zenject;

namespace Deals.Presenter.Development
{
    public class DealCreator : MonoBehaviour
    {
        private IDealCreaterView _createrView;
        private IDealPresenter _dealPresenter;
        private IStorage _inventory;

        [Inject]
        private void Construct(IDealCreaterView view, IDealPresenter dealPresenter, IStorage inventory)
        {
            _createrView = view;
            _dealPresenter = dealPresenter;
            _inventory = inventory;
        }

        private void OnEnable()
        {
            _createrView.BuildButtonClicked += OnBuildButtonClicked;
        }

        private void OnDisable()
        {
            _createrView.BuildButtonClicked -= OnBuildButtonClicked;
        }

        private void OnBuildButtonClicked(int addableValue, int removableValue, Currency addableCurrency, Currency removableCurrency)
        {
            IResource addable = new Resource(addableValue, addableCurrency);
            IResource removable = new Resource(removableValue, removableCurrency);
            IDeal deal = new Deal(removable, addable, _inventory);
            _dealPresenter.Represent(deal);
        }
    }
}