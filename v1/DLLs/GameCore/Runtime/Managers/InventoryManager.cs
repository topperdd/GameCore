using GameCore.Contexts;
using GameCore.Runtime.Events.Creation;
using GameCore.Runtime.Events.Items;
using GameCore.Runtime.Factories;
using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Managers
{
    public class InventoryManager
    {
        private GameContext _gameContext { get; set; }
        private ItemFactory _itemFactory { get; set; }

        public List<ItemInstance> ItemInstancesInInventory { get; private set; } = new List<ItemInstance>();
        public InventoryManager(GameContext gameContext)
        {
            _gameContext = gameContext;
            _itemFactory = new ItemFactory(gameContext);    

            gameContext.EventManager.Subscribe<ItemLootedEvent>(OnItemLooted);
            gameContext.EventManager.Subscribe<ItemCreatedEvent>(OnItemCreated);

            gameContext.EventManager.Subscribe<ItemInstanceUsedEvent>(OnItemInstanceUsed);
        }

        private void OnItemInstanceUsed(ItemInstanceUsedEvent e)
        {
            ItemInstancesInInventory.Remove(e.ItemInstance);
        }

        private void OnItemLooted(ItemLootedEvent e)
        {
            var itemInLoot = e.LootInstance.ItemsInLoot;

            foreach (var item in itemInLoot)
            {
                _itemFactory.CreateItemInstance(item);
            }
        }

        private void OnItemCreated(ItemCreatedEvent e)
        {
            ItemInstancesInInventory.Add(e.ItemInstance);
        }
    }
}
