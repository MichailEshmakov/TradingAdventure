using System;

namespace Deals.View
{
    public interface IDealButtons
    {
        public event Action AcceptButtonClicked;
        public event Action RejectButtonClicked;
    }
}