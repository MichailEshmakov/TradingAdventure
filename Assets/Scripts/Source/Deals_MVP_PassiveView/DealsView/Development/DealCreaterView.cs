using Goods.Model.Readonly.Resources;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Deals.View.Development
{
    public class DealCreaterView : MonoBehaviour, IDealCreaterView
    {
        [SerializeField] private TMP_InputField _removableAmount;
        [SerializeField] private TMP_Dropdown _removableCurrency;
        [SerializeField] private TMP_InputField _addableAmount;
        [SerializeField] private TMP_Dropdown _addableCurrency;
        [SerializeField] private Button _buildButton;

        public event Action<int, int, Currency, Currency> BuildButtonClicked;

        private void OnEnable()
        {
            _buildButton.onClick.AddListener(OnBuildButtonClicked);
        }

        private void OnDisable()
        {
            _buildButton.onClick.RemoveListener(OnBuildButtonClicked);
        }

        private void OnBuildButtonClicked()
        {
            if (int.TryParse(_removableAmount.text, out int removableValue) == false)
                return;

            if (int.TryParse(_addableAmount.text, out int addableValue) == false)
                return;

            BuildButtonClicked?.Invoke(addableValue,
                removableValue,
                (Currency)_addableCurrency.value,
                (Currency)_removableCurrency.value);
        }
    }
}