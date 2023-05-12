using Goods.Model.Readonly.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Goods.View
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private Image _icon; 
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ResourceIconsConfig _config;

        private IReadonlyResource _resource;

        private void OnEnable()
        {
            TryResubscribeToResource();
        }

        private void OnDisable()
        {
            TryUnsubscribeFromResource();
        }

        public void Init(IReadonlyResource resource)
        {
            _resource = resource;
            _text.text = _resource.Value.ToString();
            TryResubscribeToResource();

            if (_config.TryGetSprite(_resource.Currency, out Sprite sprite) == false)
            {
                Debug.LogError($"cannot find {resource.Currency} in {nameof(_config)}");
                return;
            }

            _icon.sprite = sprite;
        }

        private void OnResourceIncreasedBy(int delta)
        {
            _text.text = _resource.Value.ToString();
        }

        private void OnResourceDecreasedBy(int delta)
        {
            _text.text = _resource.Value.ToString();
        }

        private bool TryResubscribeToResource()
        {
            if (_resource == null)
                return false;

            if (TryUnsubscribeFromResource() == false)
                return false;

            _resource.DecreasedBy += OnResourceDecreasedBy;
            _resource.IncreasedBy += OnResourceIncreasedBy;
            return true;
        }

        private bool TryUnsubscribeFromResource()
        {
            if (_resource == null)
                return false;

            _resource.DecreasedBy -= OnResourceDecreasedBy;
            _resource.IncreasedBy -= OnResourceIncreasedBy;
            return true;
        }
    }
}