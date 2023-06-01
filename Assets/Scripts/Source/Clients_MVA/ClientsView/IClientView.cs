using Clients.View.Configs;

namespace Clients.View
{
    public interface IClientView
    {
        public void Init(IClientViewConfig config);
        public void Show();
        public void Hide();
    }
}