using Goods.Model.Readonly.Resources;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Upgrades.Presenter;
using Zenject;

namespace Upgrades.View
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private UpgradeIcon _icon;
        [SerializeField] private Button _openBuyingMenuButton;
        
        private IUpgradeBuyingMenu _buyingMenu;
        private IUpgradesPresenter _presenter;
        private bool _isAwailable = false;

        [Inject]
        private void Construct(IUpgradesPresenter presenter, IUpgradeBuyingMenu buyingMenu)
        {
            _buyingMenu = buyingMenu;
            _presenter = presenter;
        }

        private void OnEnable()
        {
            _presenter.UpgradeBought += OnUprgadeBought;

            if (_presenter.IsUpgradeBought(_name))
            {
                _isAwailable = false;
                _icon.EnterBoughtState();
                _openBuyingMenuButton.interactable = false;
            }
            else if (_presenter.IsUpgradeAwailable(_name))
            {
                _isAwailable = true;
                _icon.EnterAvailableState();
                _openBuyingMenuButton.onClick.AddListener(OnOpenBuyingMenuButtonClicked);
            }
            else
            {
                _isAwailable = false;
                _icon.EnterNotAvailableState();
                _openBuyingMenuButton.onClick.AddListener(OnOpenBuyingMenuButtonClicked);
            }
        }

        private void OnDisable()
        {
            _presenter.UpgradeBought -= OnUprgadeBought;
            _openBuyingMenuButton.onClick.RemoveListener(OnOpenBuyingMenuButtonClicked);
        }

        private void OnUprgadeBought(string name)
        {
            if (_name == name)
            {
                _icon.EnterBoughtState();
                _openBuyingMenuButton.interactable = false;
                _openBuyingMenuButton.onClick.RemoveListener(OnOpenBuyingMenuButtonClicked);
            }
        }

        private void OnOpenBuyingMenuButtonClicked()
        {

            if (_presenter.TryDownloadPrice(_name, out IEnumerable<IReadonlyResource> price))
                _buyingMenu.Open(_isAwailable, _icon.Sprite, price, _name);
            else
                Debug.LogError($"Cannot find price of {_name}");
        }
    }
}