using Goods.Model;
using Goods.Model.Readonly.Resources;
using System;

namespace Deals.Model
{
    public class Deal : IDeal
    {
        private readonly IReadonlyResource _removable;
        private readonly IReadonlyResource _addable;
        private readonly IStorage _inventory;

        public event Action Rejected;
        public event Action Accepted;

        public IReadonlyResource Removable => _removable;
        public IReadonlyResource Addable => _addable;

        public Deal(IReadonlyResource removable, IReadonlyResource addable, IStorage inventory)
        {
            if (removable == null)
                throw new ArgumentNullException(nameof(removable));

            if (addable == null)
                throw new ArgumentNullException(nameof(addable));

            if (inventory == null)
                throw new ArgumentNullException(nameof(inventory));

            if (inventory.CanStore(removable.Currency) == false)
                throw new ArgumentOutOfRangeException(nameof(removable));

            if (inventory.CanStore(addable.Currency) == false)
                throw new ArgumentOutOfRangeException(nameof(addable));

            _removable = removable;
            _addable = addable;
            _inventory = inventory;
        }

        public void Reject()
        {
            Rejected?.Invoke();
        }

        public bool TryAccept()
        {
            if (CanAccept() == false)
                return false;

            _inventory.TrySpend(_removable.Currency, _removable.Value);
            _inventory.TryAdd(_addable.Currency, _addable.Value);
            Accepted?.Invoke();
            return true;
        }

        public bool CanAccept()
        {
            return _inventory.CanSpend(_removable.Currency, _removable.Value);
        }
    }
}