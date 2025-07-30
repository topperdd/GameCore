using GameCore.DungeonEntities.Monsters;
using GameCore.Partymember;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameSystems.Factories
{
    public class DungeonEntityFactory
    {
        private List<MonsterData> _monsterDataList = new List<MonsterData>();

        public DungeonEntityFactory()
        {
            _monsterDataList = LoadMonsterResources();
        }

        public MonsterInstance CreateMonsterInstance(MonsterType monsterType)
        {
            var monsterDataToGenerate = _monsterDataList.Where(q => q.MonsterType == monsterType).FirstOrDefault();

            return new MonsterInstance(monsterDataToGenerate);
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

                MonsterData? dungeonEntityJsonConfigs = JsonSerializer.Deserialize<MonsterData>(json, options);

                if (dungeonEntityJsonConfigs != null)
                {
                    result.Add(dungeonEntityJsonConfigs);
                }
            }

            return result;
        }
    }
}
