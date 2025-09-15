using GameCore.Contexts;
using GameCore.Core.DungeonEntities;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameCore.Runtime.Factories
{
    public class DungeonEntityFactory
    {
        private List<MonsterData> _monsterDataList = new List<MonsterData>();
        private List<LootData> _lootDataList = new List<LootData>();
        private GameContext _gameContext;
        public DungeonEntityFactory(GameContext gameContext)
        {
            _monsterDataList = LoadResources<MonsterData>(DungeonEntityType.Monster);
            _lootDataList = LoadResources<LootData>(DungeonEntityType.Loot);

            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void CreateMonsterInstance(MonsterType monsterType)
        {
            var monsterDataToGenerate = _monsterDataList.Where(q => q.MonsterType == monsterType).FirstOrDefault();

            var monsterInstance = new MonsterInstance(monsterDataToGenerate, _gameContext);

            _gameContext.EventManager.Publish(new MonsterCreatedEvent(monsterInstance));
        }

        public void CreateLootInstance(LootType lootType)
        {
            var lootDataToGenerate = _lootDataList.Where(q => q.LootType == lootType).FirstOrDefault();

            var lootInstance = new LootInstance(lootDataToGenerate, _gameContext);

            _gameContext.EventManager.Publish(new LootCreatedEvent(lootInstance));
        }

        private List<T> LoadResources<T>(DungeonEntityType dungeonEntityType)
        {
            var result = new List<T>();
            string path = string.Empty;

            switch (dungeonEntityType)
            {
                case DungeonEntityType.Monster:
                    path = Path.Combine("Resources", "DungeonEntities", "Monsters");

                    break;
                case DungeonEntityType.Loot:
                    path = Path.Combine("Resources", "DungeonEntities", "Loot");
                    break;
            }

            var jsonFiles = Directory.GetFiles(path, "*.json");
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var entity in jsonFiles)
            {
                string json = File.ReadAllText(entity);
                T dungeonEntityJsonConfigs = JsonSerializer.Deserialize<T>(json, options);
                if (dungeonEntityJsonConfigs != null)
                {
                    result.Add(dungeonEntityJsonConfigs);
                }
            }

            return result;
        }
    }
}
