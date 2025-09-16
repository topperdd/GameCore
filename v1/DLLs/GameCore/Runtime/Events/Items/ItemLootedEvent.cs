using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Items
{
    public class ItemLootedEvent
    {
        public LootInstance LootInstance { get; private set; }
        public ItemLootedEvent(LootInstance lootInstance)
        {
            LootInstance = lootInstance;
        }
    }
}
