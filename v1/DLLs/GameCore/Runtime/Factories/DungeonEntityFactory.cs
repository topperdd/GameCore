using GameCore.Contexts;
using GameCore.Core.DungeonEntities.Monsters;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameCore.Runtime.Factories
{
    public class DungeonEntityFactory
    {
        private List<MonsterData> _monsterDataList = new List<MonsterData>();
        private GameContext _gameContext;
        public DungeonEntityFactory(GameContext gameContext)
        {
            _monsterDataList = LoadMonsterResources();
            _gameContext = gameContext ?? throw new ArgumentNullException(nameof(gameContext));
        }

        public void CreateMonsterInstance(MonsterType monsterType)
        {
            var monsterDataToGenerate = _monsterDataList.Where(q => q.MonsterType == monsterType).FirstOrDefault();

            var monsterInstance = new MonsterInstance(monsterDataToGenerate);
            
            _gameContext.EventManager.Publish(new MonsterCreatedEvent(monsterInstance));
        }

        private List<MonsterData> LoadMonsterResources()
        {
            var result = new List<MonsterData>();

            string path = Path.Combine("Resources", "DungeonEntities", "Monsters");
            var jsonFiles = Directory.GetFiles(path, "*.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var entity in jsonFiles)
            {
                string json = File.ReadAllText(entity);

                MonsterData dungeonEntityJsonConfigs = JsonSerializer.Deserialize<MonsterData>(json, options);

                if (dungeonEntityJsonConfigs != null)
                {
                    result.Add(dungeonEntityJsonConfigs);
                }
            }

            return result;
        }
    }
}
