namespace Clients.View.Configs
{
    public interface IAllClientsViewConfigs
    {
        public bool TryFind(string name, out ClientViewConfig foundConfig);
        public bool TryGetRandom(out ClientViewConfig randomConfig);
    }
}