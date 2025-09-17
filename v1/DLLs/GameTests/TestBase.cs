using GameCore.Contexts;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Managers;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace GameTests
{
    public abstract class TestBase
    {
        protected static ITestOutputHelper Output { get; private set; }

        protected void SetOutputHelper(ITestOutputHelper output)
        {
            Output = output;
        }

        protected void Log(string message)
        {
            Output?.WriteLine(message);
        }
        protected GameContext GameContext { get; }
        protected TargetSelectionManager TargetSelectionManager { get; }
        protected AbilityResolveManager CombatResolveManager { get; }
        protected PartymemberFactory PartymemberFactory { get; }
        protected ItemFactory ItemFactory { get; }
        protected HeroFactory HeroFactory { get; }
        protected DungeonEntityFactory DungeonEntityFactory { get; }

        protected TestBase()
        {
            GameContext = new GameContext();
            TargetSelectionManager = new TargetSelectionManager(GameContext);
            CombatResolveManager = new AbilityResolveManager(GameContext);

            PartymemberFactory = new PartymemberFactory(GameContext);
            ItemFactory = new ItemFactory(GameContext);
            HeroFactory = new HeroFactory(GameContext);
            DungeonEntityFactory = new DungeonEntityFactory(GameContext);
        }
    }
}