using Clients.View.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Clients.View
{
    public class ClientView : MonoBehaviour, IClientView
    {
        [SerializeField] private Image _body;
        [SerializeField] private Image _hair;
        [SerializeField] private Image _kit;
        [SerializeField] private Image _face;

        public void Init(IClientViewConfig config)
        {
            _body.sprite = config.Body;
            _hair.sprite = config.Hair;
            _hair.color = config.HairColor;
            _kit.sprite = config.Kit;
            _face.sprite = config.Face;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}