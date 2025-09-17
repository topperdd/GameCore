using GameCore.Contexts;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events
{
    public class LootingStartedEvent
    {
        public LootInstance LootInstance { get; set; }
        public ILooter Looter { get; set; }

        public LootingStartedEvent(LootInstance lootInstance, ILooter looter)
        {
            LootInstance = lootInstance;
            Looter = looter;    
        }
    }
}
