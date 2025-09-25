using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.DungeonEntities.Loot;
using GameCore.Core.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameCore.Runtime.Factories
{
    public class LootTableFactory
    {
        private GameContext _gameContext { get; set; }

        private List<LootTableData> _lootTableData { get; set; }

        public LootTableFactory(GameContext gameContext)
        {
            _gameContext = gameContext;

            _lootTableData = LoadResources();
        }

        public List<LootTableData> GetAllLootTables()
        {
            return _lootTableData;
        }

        private List<LootTableData> LoadResources()
        {
            string path = Path.Combine("Resources", "LootTables.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            string json = File.ReadAllText(path);

            List<LootTableData> lootTables = JsonSerializer.Deserialize<List<LootTableData>>(json, options);


            return lootTables;
        }

        internal LootTableData GetLootFromLootTableById(string lootTableId)
        {
            return _lootTableData.FirstOrDefault(lt => lt.LootTableId == lootTableId);
        }
    }
}
