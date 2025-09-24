using GameCore.Contexts;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Instances;
using GameCore.Runtime.Managers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace GameTests
{
    public abstract class TestBase
    {
        private readonly ITestOutputHelper _output;

        protected void Log(string message)
        {
            _output.WriteLine(message);
        }

        protected GameContext GameContext { get; }

        protected TestBase(ITestOutputHelper output)
        {
            GameContext = new GameContext();
           
            _output = output;

        }

        protected void SetupFightScenario()
        {
            SetupHero();
            SetupPartymembers();
            SetupMonsters(MonsterType.Any, 4);
            SetupItems();
        }

        public void SetupMonsters(MonsterType monsterType, int amount)
        {
            var type = monsterType;

            for (int i = 0; i < amount; i++)
            {
                if (monsterType == MonsterType.Any)
                {
                    var types = Enum.GetValues(typeof(MonsterType))
                                    .Cast<MonsterType>()
                                    .Where(t => t != MonsterType.Any)
                                    .ToArray();

                    var rnd = new Random();
                    type = types[rnd.Next(types.Length)];
                }

                //Log("creating of type:" + type);
                GameContext.DungeonEntityFactory.CreateMonsterInstance(type);
            }
        }

        public void SetupHero()
        {
            GameContext.HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");
        }

        public void SetupPartymembers()
        {
            GameContext.PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
            GameContext.PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Cleric);
        }

        public void SetupItems()
        {
            GameContext.DungeonEntityFactory.CreateLootInstance(LootType.TreasureChest);
        }

        public void SetupDragonScenario()
        {
            SetupHero();
            SetupPartymembers();
            SetupDragon();
        }

        private void SetupDragon()
        {
            GameContext.DungeonEntityFactory.CreateDragonInstance();
        }
    }
}