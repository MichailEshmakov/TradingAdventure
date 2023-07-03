namespace Upgrades.Model.Saving
{
    public interface IStartBoughtFlags
    {
        public bool this[string upgrade] { get; }
    }
}