using GameRuntime.Managers;

namespace GameRuntime.Contexts
{
    public class GameContext
    {
        public EventManager EventManager { get; private set; }
        public PartymemberManager PartymemberManager { get; private set; } 
        public DungeonManager DungeonManager { get; private set; }
        public InventoryManager InventoryManager { get; private set; } 


        public GameContext()
        {
            EventManager = new EventManager();
            PartymemberManager = new PartymemberManager(this);
            DungeonManager = new DungeonManager(this);
            InventoryManager = new InventoryManager(this);
        }
    }
}

