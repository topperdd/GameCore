#nullable disable

using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Core.Abilities.LootAbility;
using GameCore.Runtime.Instances;
using GameCore.Runtime.Instances.Abilities;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace GameCore.Runtime.Factories
{
    public class AbilityFactory
    {
        private GameContext _gameContext;
        private List<AttackAbilityData> _attackAbilityData = new List<AttackAbilityData>();
        private List<LootAbilityData> _lootAbilityData = new List<LootAbilityData>();

        private EffectFactory _effectFactory;

        public AbilityFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
            _effectFactory = new EffectFactory(_gameContext);

            _attackAbilityData = LoadResources<AttackAbilityData>("AttackAbility");
            _lootAbilityData = LoadResources<LootAbilityData>("LootAbility");
        }

        internal IAttackAbility CreateAttackAbilityInstance(string abilityId)
        {
            var abilityData = _attackAbilityData.FirstOrDefault(a => a.AbilityId == abilityId);

            var effects = new List<IEffect>();
            foreach (var effectId in abilityData.EffectIds)
            {
                var newEffect = _effectFactory.CreateEffectInstance(effectId);
                effects.Add(newEffect);
            }

            return new AttackAbilityInstance(abilityData, effects);
        }

        internal ILootAbility CreateLootAbilityInstance(string abilityId)
        {
            var abilityData = _lootAbilityData.FirstOrDefault(a => a.AbilityId == abilityId);

            return new LootAbilityInstance(abilityData);
        }


        private List<T> LoadResources<T>(string abilityType)
        {
            var result = new List<T>();
            string path = string.Empty;

            switch (abilityType)
            {
                case "AttackAbility":
                    path = Path.Combine("Resources", "Abilities", "AttackAbilities");

                    break;
                case "LootAbility":
                    path = Path.Combine("Resources", "Abilities", "LootAbility");
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

 