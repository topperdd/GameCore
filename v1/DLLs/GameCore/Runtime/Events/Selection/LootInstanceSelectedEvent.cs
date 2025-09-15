using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class LootInstanceSelectedEvent
    {
        public LootInstance LootInstance { get; private set; }
        public LootInstanceSelectedEvent(LootInstance lootInstance)
        {
            Console.WriteLine($"LootSelected: {lootInstance.Data.LootType}");
            LootInstance = lootInstance ?? throw new ArgumentNullException(nameof(lootInstance), "LootInstance cannot be null.");
        }
    }
}
