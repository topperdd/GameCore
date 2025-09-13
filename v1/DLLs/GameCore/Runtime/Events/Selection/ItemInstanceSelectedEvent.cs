using GameCore.Runtime.Instances;

namespace GameCore.Runtime.Events.Selection
{
    public class ItemInstanceSelectedEvent
    {
        public ItemInstance ItemInstance { get; private set; }
        public ItemInstanceSelectedEvent(ItemInstance itemInstance)
        {
            ItemInstance = itemInstance;
        }
    }
}
