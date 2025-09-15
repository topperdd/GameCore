using GameCore.Runtime.Instances;

namespace GameCore.Contexts
{
    public class ItemUseContext
    {
        public GameContext GameContext { get; set; }
        public ItemInstance ItemInstance { get; set; }
        public PartymemberInstance TargetPartymember { get; set; }
    }
}
