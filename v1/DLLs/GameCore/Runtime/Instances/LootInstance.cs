using GameCore.Contexts;
using GameCore.Core.DungeonEntities;
using GameCore.Core.Interfaces;
using GameCore.Runtime.Events;
using GameCore.Runtime.Events.Items;


namespace GameCore.Runtime.Instances
{
    public class LootInstance : ILootable
    {
        public LootData Data { get; set; }

        private GameContext _gameContext { get; set; }

        public LootInstance(LootData lootData, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = lootData;
        }

        public void Loot()
        {
            Console.WriteLine($"{this.Data.LootType} wurde gelooted!");
            _gameContext.EventManager.Publish(new ItemLootedEvent(this));
        }
    }
}
