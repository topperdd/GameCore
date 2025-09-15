using GameCore.Contexts;
using GameCore.Core.DungeonEntities;
using GameCore.Core.Interfaces;


namespace GameCore.Runtime.Instances
{
    public class LootInstance : ILootable
    {
        public LootData Data { get; set; }

        private GameContext _gameContext { get; set; }

        public LootInstance(LootData monsterData, GameContext gameContext)
        {
            _gameContext = gameContext;

            Data = monsterData;
        }

        public void Loot()
        {
            Console.WriteLine($"{this.Data.LootType} wurde gelooted!");
        }
    }
}
