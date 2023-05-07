using Goods.Model;
using Goods.Model.Readonly.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Goods.Controller.Development
{
    public class ChangingSample : MonoBehaviour
    {
        private const int FirstAmount = 1;
        private const int SecondAmount = 5;

        [SerializeField] private Button _firstAddingButton;
        [SerializeField] private Button _secondAddingButton;
        [SerializeField] private Button _firstSpendingButton;
        [SerializeField] private Button _secondSpendingButton;
        [SerializeField] private TMP_Dropdown _dropdown;

        private IStorage _inventory;

        [Inject]
        private void Construct(IStorage inventory)
        {
            _inventory = inventory;
        }

        private void OnEnable()
        {
            _firstAddingButton.onClick.AddListener(OnFirstAddingButtonClicked);
            _secondAddingButton.onClick.AddListener(OnSecondAddingButtonClicked);
            _firstSpendingButton.onClick.AddListener(OnFirstSpendingButtonClicked);
            _secondSpendingButton.onClick.AddListener(OnSecondSpendingButtonClicked);
        }

        private void OnDisable()
        {
            _firstAddingButton.onClick.RemoveListener(OnFirstAddingButtonClicked);
            _secondAddingButton.onClick.RemoveListener(OnSecondAddingButtonClicked);
            _firstSpendingButton.onClick.RemoveListener(OnFirstSpendingButtonClicked);
            _secondSpendingButton.onClick.RemoveListener(OnSecondSpendingButtonClicked);
        }

        private void OnFirstAddingButtonClicked()
        {
            _inventory.TryAdd((Currency)_dropdown.value, FirstAmount);
        }
        private void OnSecondAddingButtonClicked()
        {
            _inventory.TryAdd((Currency)_dropdown.value, SecondAmount);
        }
        private void OnFirstSpendingButtonClicked()
        {
            _inventory.TrySpend((Currency)_dropdown.value, FirstAmount);
        }
        private void OnSecondSpendingButtonClicked()
        {
            _inventory.TrySpend((Currency)_dropdown.value, SecondAmount);
        }
    }
}