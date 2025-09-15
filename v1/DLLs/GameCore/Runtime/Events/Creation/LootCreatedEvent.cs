using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Creation
{
    public class LootCreatedEvent
    {
        public LootInstance LootInstance { get; private set; }
        public LootCreatedEvent(LootInstance lootInstance)
        {
            LootInstance = lootInstance ?? throw new ArgumentNullException(nameof(lootInstance), "LootInstance cannot be null.");
        }
    }
}
