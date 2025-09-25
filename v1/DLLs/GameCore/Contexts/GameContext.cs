using GameCore.Runtime.Factories;
using GameCore.Runtime.Managers;

namespace GameCore.Contexts
{
    public class GameContext
    {
        public EventManager EventManager { get; private set; }
        public PartymemberManager PartymemberManager { get; private set; }
        public DungeonManager DungeonManager { get; private set; }
        public InventoryManager InventoryManager { get; private set; }
        public HeroManager HeroManager { get; private set; }
        public HeroPassiveEffectsManager HeroPassiveEffectsManager { get; private set; }
        public RerollManager RerollManager { get; private set; }
        public TargetSelectionManager TargetSelectionManager { get; private set; }
        public AbilityResolveManager AbilityResolveManager { get; private set; }
        public DragonManager DragonManager { get; private set; }

        public HeroFactory HeroFactory { get; private set; }
        public PartymemberFactory PartymemberFactory { get; private set; }
        public DungeonEntityFactory DungeonEntityFactory { get; private set; }
        public AbilityFactory AbilityFactory { get; private set; }
        public LootTableFactory LootFactory { get; private set; }

        public ItemFactory ItemFactory { get; private set; } 

        public GameContext()
        {
            EventManager = new EventManager();
            PartymemberManager = new PartymemberManager(this);
            DungeonManager = new DungeonManager(this);
            InventoryManager = new InventoryManager(this);
            HeroManager = new HeroManager(this);
            HeroPassiveEffectsManager = new HeroPassiveEffectsManager(this);
            RerollManager = new RerollManager(this);
            TargetSelectionManager = new TargetSelectionManager(this);
            AbilityResolveManager = new AbilityResolveManager(this);
            DragonManager = new DragonManager(this);

            HeroFactory = new HeroFactory(this);
            PartymemberFactory = new PartymemberFactory(this);
            DungeonEntityFactory = new DungeonEntityFactory(this);
            AbilityFactory = new AbilityFactory(this);
            LootFactory = new LootTableFactory(this);

            ItemFactory = new ItemFactory(this);
        }
    }
}

