using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Loot
{
    internal class LootingFinishedEvent
    {
        public LootInstance LootInstance { get; set; }

        public LootingFinishedEvent(LootInstance lootInstance)
        {
            this.LootInstance = lootInstance;
        }
    }
}