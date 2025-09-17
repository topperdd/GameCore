using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

namespace GameCore.Contexts
{
    public class LootContext
    {
        public LootInstance LootInstance { get; set; }
        public ILooter Looter { get; set; }
    }
}
