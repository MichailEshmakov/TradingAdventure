using Goods.Model.Readonly.Resources;
using System;

namespace Deals.View.Development
{
    public interface IDealCreaterView
    {
        /// <summary>
        /// addableValue, removableValue, addableCurrency, removableCurrency
        /// </summary>
        public event Action<int, int, Currency, Currency> BuildButtonClicked;
    }
}