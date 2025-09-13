#nullable disable

using GameCore.Contexts;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Core.Abilities.Effects;
using GameCore.Runtime.Instances;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace GameCore.Runtime.Factories
{
    public class AbilityFactory
    {
        private GameContext _gameContext;
        private List<AttackAbilityData> _attackAbilityData = new List<AttackAbilityData>();
        private EffectFactory _effectFactory;

        public AbilityFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
            _effectFactory = new EffectFactory(_gameContext);   
            _attackAbilityData = LoadAttackAbilityResources();
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

        private List<AttackAbilityData> LoadAttackAbilityResources()
        {
            var result = new List<AttackAbilityData>();

            string path = Path.Combine("Resources", "Abilities", "AttackAbilities");

            var jsonFiles = Directory.GetFiles(path, "*.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var attackAbility in jsonFiles)
            {
                string json = File.ReadAllText(attackAbility);

                AttackAbilityData attackAbilityData = JsonSerializer.Deserialize<AttackAbilityData>(json, options);

                result.Add(attackAbilityData);
            }

            return result;
        }
    }
}
