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
        private bool _isInited;

        private void OnEnable()
        {
            if (_resource != null)
            {
                _resource.DecreasedBy -= OnResourceDecreasedBy;
                _resource.IncreasedBy -= OnResourceIncreasedBy;
                _resource.DecreasedBy += OnResourceDecreasedBy;
                _resource.IncreasedBy += OnResourceIncreasedBy;
            }
        }

        private void OnDisable()
        {
            if (_resource != null)
            {
                _resource.DecreasedBy -= OnResourceDecreasedBy;
                _resource.IncreasedBy -= OnResourceIncreasedBy;
            }
        }

        public void Init(IReadonlyResource resource)
        {
            if (_isInited)
            {
                Debug.LogError($"{nameof(ResourceView)} in {name} is already inited");
                return;
            }

            _isInited = true;
            _resource = resource;
            _text.text = _resource.Value.ToString();
            _resource.DecreasedBy += OnResourceDecreasedBy;
            _resource.IncreasedBy += OnResourceIncreasedBy;

            if (_config.TryGetSprite(_resource.Currency, out Sprite sprite) == false)
            {
                Debug.LogError($"cannot find {resource.Currency} in {nameof(_config)}");
                return;
            }
        }

        private void OnResourceIncreasedBy(int delta)
        {
            _text.text = _resource.Value.ToString();
        }

        private void OnResourceDecreasedBy(int delta)
        {
            _text.text = _resource.Value.ToString();
        }
    }
}