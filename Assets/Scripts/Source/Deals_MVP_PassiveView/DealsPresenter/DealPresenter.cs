using Deals.Model;
using Deals.View;
using System;
using UnityEngine;
using Zenject;

namespace Deals.Presenter
{
    public class DealPresenter : IDealPresenter, IDisposable
    {
        private IDealView _view;
        private IDealButtons _buttons;
        private IDeal _deal;

        [Inject]
        private void Construct(IDealView view, IDealButtons buttons)
        {
            _view = view;
            _buttons = buttons;
            _buttons.AcceptButtonClicked += OnAcceptButtonClicked;
            _buttons.RejectButtonClicked += OnRejectButtonClicked;
        }

        public void Represent(IDeal deal)
        {
            _deal = deal;
            _view.Show();
            _view.Init(deal.Addable, deal.Removable);
        }

        public void Dispose()
        {
            if (_buttons != null)
            {
                _buttons.AcceptButtonClicked -= OnAcceptButtonClicked;
                _buttons.RejectButtonClicked -= OnRejectButtonClicked;
            }
        }

        private void OnRejectButtonClicked()
        {
            _view.Hide();

            if (_deal != null)
                _deal.Reject();
        }

        private void OnAcceptButtonClicked()
        {
            if (_deal == null)
                return;

            if (_deal.TryAccept())
                _view.Hide();
        }
    }
}