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
            HeroFactory.CreateHeroInstance("ArkanerSchwertmeister");

            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Warrior);
            PartymemberFactory.CreatePartymemberInstance(PartymemberClass.Mage);

            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Goblin);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
            DungeonEntityFactory.CreateMonsterInstance(MonsterType.Ooze);
        }
    }
}