using Deals.Model;
using Goods.Model;
using Goods.Model.Readonly.Resources;

namespace Tests.UnitTests.Deals
{
    public static class Setup
    {
        public static Deal Deal(IStorage storage, IReadonlyResource removable, IReadonlyResource addable = null)
        {
            if (addable == null)
                addable = Goods.Setup.Resource(0, 0);

            return new Deal(removable, addable, storage);
        }
    }
}