using Goods.Model.Readonly.Resources;
using Goods.View;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Deals.View
{
    public class DealView : MonoBehaviour, IDealButtons, IDealView
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _rejectButton;
        [SerializeField] private ResourceView _addableResporce;
        [SerializeField] private ResourceView _removableResporce;

        public event Action AcceptButtonClicked;
        public event Action RejectButtonClicked;

        private void OnEnable()
        {
            _acceptButton.onClick.AddListener(OnAcceptButtonClicked);
            _acceptButton.onClick.AddListener(OnRejectButtonClicked);
        }

        private void OnDisable()
        {
            _acceptButton.onClick.RemoveListener(OnAcceptButtonClicked);
            _acceptButton.onClick.RemoveListener(OnRejectButtonClicked);
        }

        public void Init(IReadonlyResource addableResource, IReadonlyResource removableResource)
        {
            _addableResporce.Init(addableResource);
            _removableResporce.Init(removableResource);
        }

        public void Hide()
        {
            _container.SetActive(false);
        }

        public void Show()
        {
            _container.SetActive(true);
        }

        private void OnAcceptButtonClicked()
        {
            AcceptButtonClicked?.Invoke();
        }

        private void OnRejectButtonClicked()
        {
            RejectButtonClicked?.Invoke();
        }
    }
}