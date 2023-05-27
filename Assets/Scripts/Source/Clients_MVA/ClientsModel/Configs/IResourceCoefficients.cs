using Goods.Model.Readonly.Resources;

namespace Clients.Model.Configs
{
    public interface IResourceCoefficients
    {
        public Currency Currency { get; }
        public float MinDemandCoefficient { get; }
        public float MaxDemandCoefficient { get; }
        public float MinSupplyCoefficient { get; }
        public float MaxSupplyCoefficient { get; }
        public float DemandChance { get; }
        public float SupplyChance { get; }
    }
}