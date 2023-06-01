namespace Clients.Model.Configs
{
    public interface IAllClients
    {
        public bool TryGetRandom(out IClient client);
    }
}