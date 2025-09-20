using GameCore.Contexts;

using System.Text.Json;
using System.Text.Json.Serialization;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Runtime.Instances;
using GameCore.Runtime.Events.Creation;
using GameCore.Core;
using GameCore.Core.Interfaces;
using GameCore.Core.Abilities.LootAbility;
using GameCore.Core.Abilities.RerollAbility;

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

            if (partymemberData.AttackAbilityIds != null)
            {
                foreach (var abilityId in partymemberData.AttackAbilityIds)
                {
                    var newAbility = _abilityFactory.CreateAttackAbilityInstance(abilityId);
                    attackAbilities.Add(newAbility);
                }
            }

            ILootAbility lootAbility = null;

            if (partymemberData.LootAbilityId != null)
            {
                lootAbility = _abilityFactory.CreateLootAbilityInstance(partymemberData.LootAbilityId);
            }

            IRerollAbility rerollAbility = null;

            if (partymemberData.RerollAbilityId != null)
            {
                rerollAbility = _abilityFactory.CreateRerollAbility(partymemberData.RerollAbilityId);
            }


            var partymemberInstance = new PartymemberInstance(partymemberData, attackAbilities, lootAbility, rerollAbility, _gameContext); 

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
