using GameCore.Contexts;
using GameCore.Core.DungeonEntities.Loot;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Items;

namespace GameCore.Runtime.Instances
{
    public class LootInstance : ILootable
    {
        public LootData Data { get; set; }

        private GameContext _gameContext { get; set; }
        public List<LootEntryData> ItemsInLoot { get; set; }

        public LootInstance(LootData lootData, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = lootData;

            ItemsInLoot = GetLootFromLootTable(Data.LootTableId);
        }

        private List<LootEntryData> GetLootFromLootTable(string lootTableId)
        {
            var rng = new Random();
            List<LootEntryData> lootedItems = new List<LootEntryData>();

            var lootTable = _gameContext.LootFactory.GetLootFromLootTableById(lootTableId);

            var totalWeight = lootTable.Items.Sum(i => i.Quantity);

            var roll = rng.Next(1, totalWeight);
            var cumulativeWeight = 0;

            foreach (var entry in lootTable.Items)
            {
                cumulativeWeight += entry.Quantity;
                if (roll < cumulativeWeight)
                {
                    lootedItems.Add(entry);
                    break;
                }
            }

            return lootedItems;
        }

        public void Loot()
        {
            _gameContext.EventManager.Publish(new ItemLootedEvent(this));
        }
    }
}
