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
        protected TargetSelectionManager TargetSelectionManager { get; }
        protected AbilityResolveManager CombatResolveManager { get; }
        protected PartymemberFactory PartymemberFactory { get; }
        protected ItemFactory ItemFactory { get; }
        protected HeroFactory HeroFactory { get; }
        protected DungeonEntityFactory DungeonEntityFactory { get; }

        protected TestBase(ITestOutputHelper output)
        {
            GameContext = new GameContext();
            TargetSelectionManager = new TargetSelectionManager(GameContext);
            CombatResolveManager = new AbilityResolveManager(GameContext);

            PartymemberFactory = new PartymemberFactory(GameContext);
            ItemFactory = new ItemFactory(GameContext);
            HeroFactory = new HeroFactory(GameContext);
            DungeonEntityFactory = new DungeonEntityFactory(GameContext);

            _output = output;

        }

        protected void SetupFightScenario()
        {
            SetupHero();
            SetupPartymembers();
            SetupMonsters(MonsterType.Any, 4);
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

                Log("creating of type:" + type);
                DungeonEntityFactory.CreateMonsterInstance(type);
            }
        }

        public void SetupHero()
        {
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");
        }

        public void SetupPartymembers()
        {
            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);
        }

        public void SetupItems()
        {

        }
    }
}