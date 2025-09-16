using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Items
{
    public class ItemInstanceUsedEvent
    {
        public ItemInstance ItemInstance { get; private set; }
        public ItemInstanceUsedEvent(ItemInstance itemInstance)
        {
            ItemInstance = itemInstance;
        }
    }
}
