using GameCore.Contexts;
using GameCore.Runtime.Managers;
using GameCore.Runtime.Factories;

namespace GameTests
{
    public abstract class TestBase
    {
        protected GameContext GameContext { get; }
        protected TargetSelectionManager TargetSelectionManager { get; }
        protected CombatResolveManager CombatResolveManager { get; }
        protected PartymemberFactory PartymemberFactory { get; }
        protected ItemFactory ItemFactory { get; }
        protected HeroFactory HeroFactory { get; }
        protected DungeonEntityFactory DungeonEntityFactory { get; }

        protected TestBase()
        {
            GameContext = new GameContext();
            TargetSelectionManager = new TargetSelectionManager(GameContext);
            CombatResolveManager = new CombatResolveManager(GameContext);

            PartymemberFactory = new PartymemberFactory(GameContext);
            ItemFactory = new ItemFactory(GameContext);
            HeroFactory = new HeroFactory(GameContext);
            DungeonEntityFactory = new DungeonEntityFactory(GameContext);
        }
    }
}