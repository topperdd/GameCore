using GameCore.Items;

namespace GameRuntime.Events.Creation
{
    public class ItemCreatedEvent
    {
        public ItemInstance ItemInstance { get; private set; }
        public ItemCreatedEvent(ItemInstance itemInstance)
        {
            ItemInstance = itemInstance;
        }
    }
}
