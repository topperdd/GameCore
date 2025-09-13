#nullable disable

using GameCore.Contexts;
using GameCore.Core.Abilities.Effects;
using GameCore.Runtime.Instances.Effects;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace GameCore.Runtime.Factories
{
    public class EffectFactory
    {
        private GameContext _gameContext;
        private List<EffectData> _effectData = new();

        public EffectFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
            _effectData = LoadEffectResources();
        }

        internal IEffect CreateEffectInstance(string effectId)
        {
            var effectData = _effectData.FirstOrDefault(a => a.EffectId == effectId);

            IEffect newEffect = null;

            switch (effectData.Type)
            {
                case EffectType.Damage:
                    newEffect = new DamageEffect(effectData);
                    break;

                case EffectType.Potion:
                    newEffect = new PotionEffect(effectData);
                    break;
            }

            return newEffect;
        }

        private List<EffectData> LoadEffectResources()
        {
            var result = new List<EffectData>();

            string path = Path.Combine("Resources", "Effects");

            var jsonFiles = Directory.GetFiles(path, "*.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var effect in jsonFiles)
            {
                string json = File.ReadAllText(effect);

                EffectData effectData = JsonSerializer.Deserialize<EffectData>(json, options);

                result.Add(effectData);
            }

            return result;
        }
    }
}
