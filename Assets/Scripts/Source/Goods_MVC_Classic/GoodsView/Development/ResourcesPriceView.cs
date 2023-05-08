using Goods.Model.Readonly;
using TMPro;
using UnityEngine;
using Zenject;

namespace Goods.View.Development
{
    public class ResourcesPriceView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _price;

        private IReadonlyResourcePricePublisher _pricePublisher;

        [Inject]
        private void Construct(IReadonlyResourcePricePublisher pricePublisher)
        {
            _pricePublisher = pricePublisher;
            _price.text = _pricePublisher.ComputePrice().ToString();
        }

        private void OnEnable()
        {
            _pricePublisher.PriceChanged += OnPriceChanged;
        }

        private void OnDisable()
        {
            _pricePublisher.PriceChanged -= OnPriceChanged;
        }

        private void OnPriceChanged()
        {
            _price.text = _pricePublisher.ComputePrice().ToString();
        }
    }
}