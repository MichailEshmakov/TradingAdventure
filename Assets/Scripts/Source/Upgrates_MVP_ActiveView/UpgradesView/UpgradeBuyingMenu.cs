using Goods.Model.Readonly.Resources;
using Goods.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Upgrades.Presenter;
using Zenject;

namespace Upgrades.View
{
    public class UpgradeBuyingMenu : MonoBehaviour, IUpgradeBuyingMenu
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private List<ResourceView> _resourceViews;
        [SerializeField] private UpgradeIcon _icon;

        private IUpgradesPresenter _presenter;
        private string _upgradeName;

        [Inject]
        private void Consruct(IUpgradesPresenter presenter)
        {
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _buyButton.onClick.AddListener(OnBuyButtonClicked);
        }

        private void OnDisable()
        {
            _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
        }

        public void Open(bool isAwailable, Sprite sprite, IEnumerable<IReadonlyResource> price, string upgradeName)
        {
            gameObject.SetActive(true);
            _upgradeName = upgradeName;

            _resourceViews.Zip(price, (view, pricePart) => (view, pricePart))
                .ToList()
                .ForEach(resource => resource.view.Init(resource.pricePart));

            _icon.SetSprite(sprite);
            _buyButton.interactable = isAwailable;

            if (isAwailable)
                _icon.EnterAvailableState();
            else
                _icon.EnterNotAvailableState();
        }

        private void OnBuyButtonClicked()
        {
            if (_presenter.TryBuy(_upgradeName) == false)
                Debug.LogError($"Cannot buy {_upgradeName}");
        }
    }
}