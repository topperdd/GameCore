using GameCore.Contexts;
using GameCore.Core;
using GameCore.Core.Abilities.AttackAbility;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Instances;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameCore.Runtime.Factories
{
    public class HeroFactory
    {
        private List<HeroData> _heroBaseDataList = new List<HeroData>();
        private GameContext _gameContext;

        public HeroFactory(GameContext gameContext)
        {
            _heroBaseDataList = LoadResources<HeroData>(HeroType.Base);
            _gameContext = gameContext;
        }

        public void CreateHeroBaseInstance(string heroBase)
        {
            var heroBaseData = _heroBaseDataList.FirstOrDefault(p => p.HeroId == heroBase);

            //var attackAbilities = new List<IAttackAbility>();

            //foreach (var abilityId in heroBaseData.AttackAbilityIds)
            //{
            //    var newAbility = _abilityFactory.CreateAttackAbilityInstance(abilityId);
            //    attackAbilities.Add(newAbility);
            //}

            //var lootAbility = _abilityFactory.CreateLootAbilityInstance(heroBaseData.LootAbilityId);

            var heroBaseInstance = new HeroInstance(heroBaseData, _gameContext);

            _gameContext.EventManager.Publish(new BaseHeroCreatedEvent(heroBaseInstance));
        }

        private List<T> LoadResources<T>(HeroType heroType)
        {
            var result = new List<T>();
            string path = string.Empty;

            switch (heroType)
            {
                case HeroType.Base:
                    path = Path.Combine("Resources", "Heroes", "Base");
                    break;
                case HeroType.LevelUp:
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

