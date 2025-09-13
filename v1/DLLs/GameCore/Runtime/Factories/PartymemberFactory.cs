using GameCore.Contexts;

using System.Text.Json;
using System.Text.Json.Serialization;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Partymember;
using GameCore.Runtime.Instances;
using GameCore.Runtime.Events.Creation;

namespace GameCore.Runtime.Factories
{
    public class PartymemberFactory
    {
        private List<PartymemberData> _partymemberDataList = new List<PartymemberData>();
        private GameContext _gameContext;
        private AbilityFactory _abilityFactory;

        public PartymemberFactory(GameContext gameContext)
        {
            _partymemberDataList = LoadPartymemberResources();
            _gameContext = gameContext;
            _abilityFactory = new AbilityFactory(_gameContext);
        }

        public void CreatePartymemberInstance(PartymemberClass partymemberClass)
        {
            var partymemberData = _partymemberDataList.FirstOrDefault(p => p.Class == partymemberClass);

            var attackAbilities = new List<IAttackAbility>();

            foreach (var abilityId in partymemberData.AttackAbilityIds)
            {
                var newAbility = _abilityFactory.CreateAttackAbilityInstance(abilityId);
                attackAbilities.Add(newAbility);
            }

            var partymemberInstance = new PartymemberInstance(partymemberData, attackAbilities); 

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
