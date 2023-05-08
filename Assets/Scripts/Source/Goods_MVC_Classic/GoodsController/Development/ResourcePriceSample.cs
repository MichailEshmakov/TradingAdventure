using Goods.Model;
using Goods.Model.Readonly;
using Goods.Model.Readonly.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Goods.Controller.Development
{
    public class ResourcePriceSample : MonoBehaviour
    {
        private const float FirstCoefficient = 2f;
        private const float SecondCoefficient = 3f;

        [SerializeField] private Toggle _firstToggle;
        [SerializeField] private Toggle _secondToggle;
        [SerializeField] private TMP_Dropdown _dropdown;

        private IResourcePricePublisher _resourcePricePublisher;
        private IReadonlyStorage _storage;
        private IPriceCoefficient _firstCoefficient;
        private IPriceCoefficient _secondCoefficient;

        [Inject]
        private void Construct(IResourcePricePublisher resourcePricePublisher, IReadonlyStorage storage)
        {
            _resourcePricePublisher = resourcePricePublisher;
            _storage = storage;
            _firstCoefficient = new PriceCoefficient(FirstCoefficient);
            _secondCoefficient = new PriceCoefficient(SecondCoefficient);

            if (_firstToggle.isOn)
                _resourcePricePublisher.TryAddCoefficient(_firstCoefficient);

            if (_secondToggle.isOn)
                _resourcePricePublisher.TryAddCoefficient(_secondCoefficient);
        }
        
        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
            _firstToggle.onValueChanged.AddListener(OnFirstToggleValueChanged);
            _secondToggle.onValueChanged.AddListener(OnSecondToggleValueChanged);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(OnDropdownValueChanged);
            _firstToggle.onValueChanged.RemoveListener(OnFirstToggleValueChanged);
            _secondToggle.onValueChanged.RemoveListener(OnSecondToggleValueChanged);
        }

        private void OnDropdownValueChanged(int dropdownValue)
        {
            _storage.TryFindResource((Currency)dropdownValue, out IReadonlyResource resource);
            if (resource != null)
                _resourcePricePublisher.SetResource(resource);
        }

        private void OnFirstToggleValueChanged(bool isOn)
        {
            if (isOn)
                _resourcePricePublisher.TryAddCoefficient(_firstCoefficient);
            else
                _resourcePricePublisher.TryRemoveCoefficient(_firstCoefficient);
        }

        private void OnSecondToggleValueChanged(bool isOn)
        {
            if (_secondToggle.isOn)
                _resourcePricePublisher.TryAddCoefficient(_secondCoefficient);
            else
                _resourcePricePublisher.TryRemoveCoefficient(_secondCoefficient);
        }
    }
}