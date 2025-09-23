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
        private Dictionary<string, EffectData> _effectData = new();

        public EffectFactory(GameContext gameContext)
        {
            _gameContext = gameContext;
            LoadEffectResources();
        }

        internal IEffect CreateEffectInstance(string effectId)
        {
            var data = GetEffectData<EffectData>(effectId);

            return effectId switch
            {
                "Damage" => new KillMonsterEffect((DamageEffectData)data),
                "RevivePartymember" => new ReviveEffect((ReviveEffectData)data),
                "MageToWarriorAttackerConversion" => new AttackerConversionEffect((AttackerConversionEffectData)data),
                "WarriorToMageAttackerConversion" => new AttackerConversionEffect((AttackerConversionEffectData)data),
                "RemoveAllMonsters" => new RemoveAllMonstersEffect((RemoveAllMonstersData)data),
                "RemoveAllLoot" => new RemoveAllLootEffect((RemoveAllLootData)data),
                "RerollEntities" => new RerollEntitiesEffect((RerollEntitiesEffectData)data),
                _ => throw new ArgumentException($"Unknown effect: {effectId}")
            };
        }

        internal List<IEffect> CreateEffects(List<string> effectIds)
        {
            var effects = new List<IEffect>();

            if (effectIds != null)
            {
                foreach (var effect in effectIds)
                {
                    effects.Add(CreateEffectInstance(effect));
                }
            }

            return effects;
        }

        private void LoadEffectResources()
        {
            string path = Path.Combine("Resources", "Effects.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            string json = File.ReadAllText(path);

            // Erst mal "roh" als JsonDocument laden
            using var doc = JsonDocument.Parse(json);
            foreach (var element in doc.RootElement.EnumerateArray())
            {
                var type = element.GetProperty("EffectId").GetString();

                EffectData effect = type switch
                {
                    "Damage" => JsonSerializer.Deserialize<DamageEffectData>(element.GetRawText(), options),
                    "RevivePartymember" => JsonSerializer.Deserialize<ReviveEffectData>(element.GetRawText(), options),
                    "MageToWarriorAttackerConversion" => JsonSerializer.Deserialize<AttackerConversionEffectData>(element.GetRawText(), options),
                    "WarriorToMageAttackerConversion" => JsonSerializer.Deserialize<AttackerConversionEffectData>(element.GetRawText(), options),
                    "RemoveAllMonsters" => JsonSerializer.Deserialize<RemoveAllMonstersData>(element.GetRawText(), options),
                    "RemoveAllLoot" => JsonSerializer.Deserialize<RemoveAllLootData>(element.GetRawText(), options),
                    "RerollEntities" => JsonSerializer.Deserialize<RerollEntitiesEffectData>(element.GetRawText(), options),
                    _ => throw new ArgumentException($"Unknown effect id: {type}")
                };

                _effectData[effect.EffectId] = effect;
            }
        }

        private T GetEffectData<T>(string effectId) where T : EffectData
        {
            return _effectData[effectId] as T;
        }
    }
}
