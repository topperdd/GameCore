using GameCore.Abilities;
using GameCore.Abilities.AttackAbility;
using GameCore.Abilities.Effects;
using GameCore.Items;
using GameCore.Partymember;
using GameRuntime.Contexts;
using GameRuntime.Events.Creation;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameSystems.Factories
{
    public class ItemFactory
    {
        private List<ItemData> _itemDataList = new List<ItemData>();
        private GameContext _gameContext;
        private EffectFactory _effectFactory;

        public ItemFactory(GameContext gameContext)
        {
            _itemDataList = LoadItemResources();
            _gameContext = gameContext;
            _effectFactory = new EffectFactory(_gameContext);
        }

        public void CreateItemInstance(string itemId)
        {
            var itemData = _itemDataList.FirstOrDefault(a => a.ItemId == itemId);

            var effects = new List<IEffect>();

            foreach (var effectId in itemData.EffectIds)
            {
                var newEffect = _effectFactory.CreateEffectInstance(effectId);
                effects.Add(newEffect);
            }
         
            var itemInstance = new ItemInstance(itemData, effects);

            _gameContext.EventManager.Publish(new ItemCreatedEvent(itemInstance));
        }

        private List<ItemData> LoadItemResources()
        {
            var result = new List<ItemData>();

            string path = Path.Combine("Resources", "Items");

            var jsonFiles = Directory.GetFiles(path, "*.json");

            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true
            };

            foreach (var partymember in jsonFiles)
            {
                string json = File.ReadAllText(partymember);

                ItemData itemData = JsonSerializer.Deserialize<ItemData>(json, options);

                result.Add(itemData);
            }

            return result;
        }
    }
}

