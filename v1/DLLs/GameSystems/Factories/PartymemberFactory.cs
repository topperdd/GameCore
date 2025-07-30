using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameSystems.Factories
{
    public class PartymemberFactory
    {
        private List<PartymemberData> _partymemberDataList = new List<PartymemberData>();
        private GameContext _gameContext;

        public PartymemberFactory(GameContext gameContext)
        {
            _partymemberDataList = LoadPartymemberResources();
            _gameContext = gameContext;
        }

        public void CreatePartymemberInstance(PartymemberClass partymemberClass)
        {
            var partymemberData = _partymemberDataList.FirstOrDefault(p => p.Class == partymemberClass);
            if (partymemberData == null)
            {
                throw new ArgumentException($"Partymember with name '{partymemberClass}' not found.");
            }
            
            var partymemberInstance = new PartymemberInstance(partymemberData); 

            _gameContext.EventManager.Publish(new PartymemberCreatedEvent(partymemberInstance));
        }

        private List<PartymemberData> LoadPartymemberResources()
        {
            var result = new List<PartymemberData>();

            string path = Path.Combine("Resources", "Partymembers");

            var jsonFiles = Directory.GetFiles(path, "*.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var partymember in jsonFiles)
            {
                string json = File.ReadAllText(partymember);

                PartymemberData partymemberData = JsonSerializer.Deserialize<PartymemberData>(json, options);

                result.Add(partymemberData);
            }

            return result;
        }
    }
}
