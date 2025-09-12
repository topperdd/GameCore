using GameCore.Items;
using GameRuntime.Contexts;
using GameRuntime.Events.Creation;

namespace GameRuntime.Managers
{
    public class InventoryManager
    {
        public List<ItemInstance> ItemInstances { get; private set; } = new List<ItemInstance>();
        public InventoryManager(GameContext gameContext)
        {
            gameContext.EventManager.Subscribe<ItemCreatedEvent>(OnItemCreated);
        }
        private void OnItemCreated(ItemCreatedEvent e)
        {
            ItemInstances.Add(e.ItemInstance);
        }
    }
}
