using Goods.Model.Configs;
using Goods.Model.Readonly.Resources;
using System;
using System.Collections.Generic;

namespace Goods.Model
{
    public class ResourcePricePublisher : IDisposable, IResourcePricePublisher
    {
        private const float CoefficientWithNoChanging = 1f;

        private readonly IBasicPricesConfig _config;
        private IReadonlyResource _resource;
        private IFinalPrice _oneItemPrice;

        public event Action PriceChanged;

        public ResourcePricePublisher(IBasicPricesConfig config, IReadonlyResource resource)
        {
            _config = config;
            SetResource(resource);
        }

        public float ComputePrice()
        {
            return _oneItemPrice.ComputeValue() * _resource.Value;
        }

        public bool TryAddCoefficient(IPriceCoefficient coefficient)
        {
            bool isAdded = _oneItemPrice.TryAddCoefficient(coefficient);

            if (coefficient.Value != CoefficientWithNoChanging)
                PriceChanged?.Invoke();

            return isAdded;
        }

        public bool TryRemoveCoefficient(IPriceCoefficient coefficient)
        {
            bool isRemoved = _oneItemPrice.TryRemoveCoefficient(coefficient);

            if (coefficient.Value != CoefficientWithNoChanging)
                PriceChanged?.Invoke();

            return isRemoved;
        }

        public void SetResource(IReadonlyResource resource)
        {
            if (_resource == resource)
                return;

            if (_config.TryFindPrice(resource.Currency, out float price) == false)
                throw new Exception($"Cannot find {nameof(price)} of {resource.Currency}");

            if (_resource != null)
                UnsubscribeFrom(_resource);

            _resource = resource;
            SubscribeTo(_resource);
            SetBasicPrice(price);
            PriceChanged?.Invoke();
        }

        public void Dispose()
        {
            UnsubscribeFrom(_resource);
        }

        private void SubscribeTo(IReadonlyResource resource)
        {
            resource.IncreasedBy += OnResourceIncreasedBy;
            resource.DecreasedBy += OnResourceDecreasedBy;
        }

        private void UnsubscribeFrom(IReadonlyResource resource)
        {
            resource.IncreasedBy -= OnResourceIncreasedBy;
            resource.DecreasedBy -= OnResourceDecreasedBy;
        }

        private void OnResourceDecreasedBy(int delta)
        {
            PriceChanged?.Invoke();
        }

        private void OnResourceIncreasedBy(int delta)
        {
            PriceChanged?.Invoke(); ;
        }

        private void SetBasicPrice(float basicPrice)
        {
            if (_oneItemPrice != null)
            {
                IEnumerable<IPriceCoefficient> coefficients = _oneItemPrice.Coefficients;
                _oneItemPrice = new FinalPrice(basicPrice, coefficients);
            }
            else
            {
                _oneItemPrice = new FinalPrice(basicPrice);
            }
        }
    }
}