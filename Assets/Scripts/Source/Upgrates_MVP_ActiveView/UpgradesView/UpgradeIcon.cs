using UnityEngine;
using UnityEngine.UI;

namespace Upgrades.View
{
    public class UpgradeIcon : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _borders;
        [SerializeField] private Color _boughtIconColor;
        [SerializeField] private Color _notBoughtIconColor;
        [SerializeField] private Color _availableBordersColor;
        [SerializeField] private Color _notAvailableBordersColor;
        [SerializeField] private Color _boughtBordersColor;

        public Sprite Sprite => _icon.sprite;

        public void EnterBoughtState()
        {
            _icon.color = _boughtIconColor;
            _borders.color = _boughtBordersColor;
        }

        public void EnterAvailableState()
        {
            _icon.color = _notBoughtIconColor;
            _borders.color = _availableBordersColor;
        }

        public void EnterNotAvailableState()
        {
            _icon.color = _notBoughtIconColor;
            _borders.color = _notAvailableBordersColor;
        }

        public void SetSprite(Sprite sprite)
        {
            _icon.sprite = sprite;
        }
    }
}